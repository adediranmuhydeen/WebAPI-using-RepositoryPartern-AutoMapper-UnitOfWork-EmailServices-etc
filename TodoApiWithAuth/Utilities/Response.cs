namespace TodoApiWithAuth.Utilities
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }

        public Response(int statusCode, string message, bool success, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Success = success;
            Data = data;
        }
        public Response()
        {

        }

        public static Response<T> Fail(int statusCode, string message)
        {
            return new Response<T> { StatusCode = statusCode, Message = message, Success = false };
        }
        public static Response<T> Successful(string message, bool success, T data, int statusCode = 200)
        {
            return new Response<T> { StatusCode = statusCode, Message = message, Success = true, Data = data };
        }

    }
}
