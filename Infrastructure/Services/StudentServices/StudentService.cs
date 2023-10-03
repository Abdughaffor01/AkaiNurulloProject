using System.Net;
using AutoMapper;
using Domain;
using Domain.DTOs.StudentDTOs;
using Domain.Filters;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;
public class StudentService : IStudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<List<GetStudentDto>>> GetStudentsAsync(GetStudentFilter filter)
    {
        var students = _context.Students.AsQueryable();
            if (filter.Name != null)
            {
                students = students.Where(st => st.FirstName.Contains(filter.Name));
            }

            filter = new GetStudentFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = await students.CountAsync();
            var paged = students.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
            var mappedStudents=_mapper.Map<List<GetStudentDto>>(paged);

            return new PaginationResponse<List<GetStudentDto>>(mappedStudents,filter.PageNumber,filter.PageSize,totalRecords);
    }

    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return new Response<GetStudentDto>(HttpStatusCode.NotFound,"not found");
            
            var mapperStudents=_mapper.Map<GetStudentDto>(student);

            return new Response<GetStudentDto>(mapperStudents);

        }
        catch (Exception ex)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<AddStudentDto>> AddStudentAsync(AddStudentDto model)
    {
        try
        {
            //automapper
            var student = _mapper.Map<Student>(model);
            student.JoinDate = DateTime.UtcNow;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return new Response<AddStudentDto>(model);
        }
        catch (Exception ex)
        {
            return new Response<AddStudentDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model)
    {
        try
        {
            var student = await _context.Students.FindAsync(model.Id);
            if (student == null) return new Response<BaseStudentDto>(HttpStatusCode.NotFound,"student not found");
            _mapper.Map(model,student);
            await _context.SaveChangesAsync();
            var baseStudent = _mapper.Map<BaseStudentDto>(student);
            return new Response<BaseStudentDto>(baseStudent);
        }
        catch (Exception ex)
        {
            return new Response<BaseStudentDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return new Response<string>(HttpStatusCode.NotFound,"not found");
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted student");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    
}
