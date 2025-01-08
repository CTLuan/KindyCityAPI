using KindyCity.Shared.Commons;
using KindyCity.Shared.Constants;
using System.Net;

namespace KindyCity.Shared.Exceptions
{
    public class ForbiddenAccessException : BaseException
    {
        public ForbiddenAccessException(string message = ErrorMessages.MESSAGE_ERROR_REQUEST_UNAUTHORIZEDACCESS)
           : base(message, (int)HttpStatusCode.Forbidden)
        {
        }
    }
}
