namespace YemekTarifleriApi.Application.Wrappers;

public class Response<T>
{
  public T Data { get; set; }
  public bool Succeeded { get; set; }

  public Response()
  {
  }

  public Response(T data)
  {
    Succeeded = true;
    Data = data;
  }
}