using System.Net;
namespace Domain.Wrapper;
public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
    public Response() { }
    public Response(T data)
    {
        Data = data;
        StatusCode = 200;
    }
    public Response(HttpStatusCode code,string message)
    {
        StatusCode = (int)code;
        Errors = new List<string>() { message };
    }
}