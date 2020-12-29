using System.Text.Json;

namespace WebAPI.Errors
{
    public class APIError
    {
        public APIError(int errorCode, string errorMessage, string errorDetails = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorDetails { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
