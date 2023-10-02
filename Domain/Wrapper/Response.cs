using System.Net;

namespace Domain;
public class Response<T>
{
    public int StatusCode { get; set; }
    public string Mesegge { get; set; }
    public T Data { get; set; }
    public Response(HttpStatusCode code) => StatusCode = (int)code;
    public Response(T data) => Data =data;
    public Response(HttpStatusCode code,string messege)
    {
        StatusCode = (int)code;
        Mesegge = messege;
    }
}
