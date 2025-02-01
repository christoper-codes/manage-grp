using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.Helpers
{
    public static class ApiResponse
    {
        public static IActionResult SendResponse<T>(bool success, string message, T data, int statusCode)
        {
            var response = new ResponseHelper<T>(success, message, data, statusCode);
            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }

        public static IActionResult SendSuccess<T>(string message, T data)
        {
            return SendResponse(true, message, data, 200);
        }

        public static IActionResult SendError<T>(string message, T data, int statusCode)
        {
            return SendResponse(false, message, data, statusCode);
        }
    }
}
