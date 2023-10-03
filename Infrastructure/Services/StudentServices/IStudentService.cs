using Domain;
using Domain.DTOs.StudentDTOs;
using Domain.Filters;
using Domain.Wrapper;

namespace Infrastructure;
public interface IStudentService
{   
    Task<PaginationResponse<List<GetStudentDto>>> GetStudentsAsync(GetStudentFilter filter);
    Task<Response<GetStudentDto>> GetStudentByIdAsync(int id);
    Task<Response<AddStudentDto>> AddStudentAsync(AddStudentDto model);
    Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model);
    Task<Response<string>> DeleteStudentAsync(int id);
}
