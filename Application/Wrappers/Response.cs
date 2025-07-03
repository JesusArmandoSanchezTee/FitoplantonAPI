namespace Application.Wrappers;

public class Response<T>
{
    public Response() { }

    public Response(T data, string message = null)
    {
        Succeeded = true;
        Mesaage = message;
        Result = data;
    }

    public Response(string mesaage)
    {
        Succeeded = false;
        Mesaage = mesaage;
        
    }

    public T Result { get; set; }
    public string Mesaage { get; set; }
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; }
}