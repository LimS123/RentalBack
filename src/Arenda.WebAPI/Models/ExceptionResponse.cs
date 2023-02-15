namespace Arenda.WebAPI.Models
{
    public class ExceptionResponse
    {
        public ExceptionResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
