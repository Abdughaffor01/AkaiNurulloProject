using Domain;
using Domain.DTOs.StudentDTOs;
using Domain.Filters;
using Domain.Wrapper;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;
    public StudentController(IStudentService service)=>_service = service;

    [HttpGet("GetStudentsAsync")]
    public async Task<PaginationResponse<List<GetStudentDto>>> GetStudentsAsync(GetStudentFilter filter)
    {
         return await _service.GetStudentsAsync(filter);
    }

    [HttpGet("GetStudentByIdAsync")]
    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        return await _service.GetStudentByIdAsync(id);
    }

    [HttpPost("AddStudent")]
    public async Task<Response<AddStudentDto>> AddStudentAsync(AddStudentDto model)
    {
        return await _service.AddStudentAsync(model);
    }

    [HttpPut("UpdateStudentAsync")]
    public async Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model)
    {
        return await _service.UpdateStudentAsync(model);
    }

    [HttpDelete("DeleteStudentAsync")]
    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        return await _service.DeleteStudentAsync(id);
    }
}