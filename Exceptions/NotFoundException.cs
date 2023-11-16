using System.Net;
using RotaLimpa.Api.Exceptions.constraints;
using RotaLimpa.Api.Exceptions;

namespace RotaLimpa.Api.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource) :
            base
            (
                ErrorCode.NOT_FOUND,
                $"{resource} not found",
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                new HttpContextAccessor()?.HttpContext?.Request.Path,
                DateTimeOffset.UtcNow,
                null
            )
        { }

        public NotFoundException(string message, string uriPath, Exception ex) :
            base
            (
                ErrorCode.NOT_FOUND,
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                uriPath,
                DateTimeOffset.UtcNow,
                ex
            )
        { }
    }
}