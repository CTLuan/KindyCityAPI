using KindyCity.Shared.Commons;
using KindyCity.Shared.Constants;
using System.Net;

namespace KindyCity.Shared.Exceptions
{
    public class ValidationException : BaseException
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }

        public ValidationException(IReadOnlyDictionary<string, string[]> errors, string message = ErrorMessages.MESSAGE_ERROR_INPUT_VALIDATIONFAILED)
             : base(message, (int)HttpStatusCode.BadRequest)
        {
            Errors = errors;
        }
    }
}
