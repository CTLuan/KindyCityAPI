using KindyCity.Shared.Commons;

namespace KindyCity.Shared.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message) : base(message, 409)
        {
        }
    }
}
