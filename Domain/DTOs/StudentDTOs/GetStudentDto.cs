namespace Domain;
public class GetStudentDto
{
    public int Id { get; set; }
    public string FulName { get; set; }
    public string EmailAddress { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime JoinDate { get; set; }
}
