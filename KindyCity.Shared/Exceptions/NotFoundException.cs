using KindyCity.Shared.Commons;
using KindyCity.Shared.Constants;
using System.Net;

namespace KindyCity.Shared.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message = ErrorMessages.MESSAGE_ERROR_REQUEST_NOTFOUND)
           : base(message, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
