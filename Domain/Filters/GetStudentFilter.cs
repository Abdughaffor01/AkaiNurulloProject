namespace Domain.Filters;

public class GetStudentFilter : PaginationFilter
{
    public string? Name { get; set; }
    
    public GetStudentFilter(int pageNumber, int pageSize):base(pageNumber,pageSize)
    {
        
    }

    public GetStudentFilter()
    {
        
    }
}