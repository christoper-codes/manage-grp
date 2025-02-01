namespace manage_grp.Server.Helpers
{
    public class ResponseHelper<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public ResponseHelper(bool success, string message, T data, int statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }
    }
}
