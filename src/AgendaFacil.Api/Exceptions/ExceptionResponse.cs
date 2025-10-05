namespace AgendaFacil.Api.Exceptions;

public class ExceptionResponse
{
    public int StatusCode { get; set; }
    public string? Title { get; set; }
    public string? ExceptionMessage { get; set; }
    public DateTime ExceptionDateTime { get; set; }
    public string? StackTrace { get; set; }
}
