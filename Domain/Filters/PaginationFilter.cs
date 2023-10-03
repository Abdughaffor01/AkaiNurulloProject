namespace Domain.Filters;

public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PaginationFilter()
    {
        
    }
    public PaginationFilter(int pageNumber, int pageSize)
    {
        if (PageNumber <= 0) PageNumber = 1;
        if (PageSize <= 0) PageSize = 10;
    }
    
}