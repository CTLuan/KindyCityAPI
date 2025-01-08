namespace KindyCity.API.Exceptions
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public IReadOnlyDictionary<string, string[]> Errors { get; set; }
        public ApiException(int statusCode, string message, string details, Exception exception)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
            Errors = new Dictionary<string, string[]>();
        }
        public ApiException(int statusCode, string message, string details = "")
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
            Errors = new Dictionary<string, string[]>();
        }
    }
}
