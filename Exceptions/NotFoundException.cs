using System.Net;

namespace RotaLimpa.Api.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource) :
            base(
                "ERRO:001",
                $"{resource} not found",
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                null
            )
        { }

        public NotFoundException(string message, Exception ex) :
            base(
                "ERRO:001",
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                ex
            )
        { }
    }
}