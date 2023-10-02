using Domain;
namespace Infrastructure;
public interface IStudentService
{   
    Task<Response<List<GetStudentDto>>> GetStudentsAsync();
    Task<Response<GetStudentDto>> GetStudentByIdAsync(int id);
    Task<Response<AddStudentDto>> AddStudentAsync(AddStudentDto model);
    Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model);
    Task<Response<string>> DeleteStudentAsync(int id);
}
