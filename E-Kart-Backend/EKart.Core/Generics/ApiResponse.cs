namespace EKart.Core.Generics
{
    public class ApiResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
    public static class ApiResponse
    {
        public static ApiResponseModel<T> Success<T>(T data, string message = "Success")
        {
            return new ApiResponseModel<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponseModel<T> Failure<T>(string message = "An error occurred")
        {
            return new ApiResponseModel<T>
            {
                Success = false,
                Message = message,
                Data = default
            };
        }
    }
}
