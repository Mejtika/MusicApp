using MusicApp.Middlewares.Exceptions;

namespace MusicApp.Users.Exceptions
{
    public class InvalidUserDataException : MusicException
    {
        public InvalidUserDataException(string message) : base(message)
        {
        }
    }
} 