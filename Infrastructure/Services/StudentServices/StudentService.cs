using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Infrastructure;
public class StudentService : IStudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        try
        {
            var students = await _context.Students.Select(s=>new GetStudentDto() { 
                Id=s.Id,
                FulName=s.FirstName+" "+s.LastName,
                Address=s.Address,
                BirthDate=s.BirthDate,
                EmailAddress=s.Email,
                Gender=s.Gender,
                JoinDate=s.JoinDate,
                Phone=s.Phone
            }).ToListAsync();
            if (students.Count == 0) return new Response<List<GetStudentDto>>(HttpStatusCode.NoContent);

            // AutoMapper var mapperStudents=_mapper.Map<List<GetStudentDto>>(students);

            return new Response<List<GetStudentDto>>(students);
            
        }
        catch (Exception ex)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return new Response<GetStudentDto>(HttpStatusCode.NoContent);

            var studentMap = new GetStudentDto() { 
                Id = id,
                Address = student.Address,
                BirthDate = student.BirthDate,
                EmailAddress = student.Email,
                FulName = student.FirstName+" "+student.LastName,
                Gender = student.Gender,
                Phone = student.Phone,
                JoinDate=student.JoinDate
            };

            // AutoMapper var mapperStudents=_mapper.Map<List<GetStudentDto>>(students);

            return new Response<GetStudentDto>(studentMap);

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
            var student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Gender = model.Gender,
                Phone = model.Phone,
                JoinDate = DateTime.UtcNow
            };

            //automapper
            //var student = _mapper.Map<Student>(model);
            //student.JoinDate = DateTime.UtcNow;

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
            if (student == null) return new Response<BaseStudentDto>(HttpStatusCode.NoContent);
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Address = model.Address;
            student.BirthDate = model.BirthDate;
            student.Email = model.Email;
            student.Gender = model.Gender;
            student.Phone = model.Phone;

            //automapper  _mapper.Map(model,student); 

            _context.Students.Update(student);
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
            if (student == null) return new Response<string>(HttpStatusCode.NoContent);
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
