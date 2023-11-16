using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RotaLimpa.Api.http
{
    public class HttpResponseApi<T> where T : class
    {
        public T Data { get; private set; }
        public string Message { get; private set; }
        public int StatusCode { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        private HttpResponseApi(T data, string message, HttpStatusCode statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = (int)statusCode;
            Timestamp = DateTimeOffset.UtcNow;
        }

        public static IActionResult Ok(T data)
        {
            var httpResponse = new HttpResponseApi<T>(data, "Operation Successful", HttpStatusCode.OK);
            return new ObjectResult(httpResponse) { StatusCode = httpResponse.StatusCode };
        }

        public static IActionResult Created(T data)
        {
            var httpResponse = new HttpResponseApi<T>(data, "Created successfully", HttpStatusCode.Created);
            return new ObjectResult(httpResponse) { StatusCode = httpResponse.StatusCode };
        }

        public static IActionResult NoContent()
        {
            var httpResponse = new HttpResponseApi<T>(null, "Done", HttpStatusCode.NoContent);
            return new ObjectResult(httpResponse) { StatusCode = httpResponse.StatusCode };
        }
    }
}