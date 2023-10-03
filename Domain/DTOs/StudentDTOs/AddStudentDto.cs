namespace Domain.DTOs.StudentDTOs;
public class AddStudentDto:BaseStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    
}
