using Domain.DTOs.StudentDTOs;
namespace Domain;
public class GetStudentDto : BaseStudentDto
{
    public string Gender { get; set; }
    public string FullName { get; set; }
    public string EmailAddress { get; set; }
}
