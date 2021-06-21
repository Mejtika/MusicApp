using MusicApp.Middlewares.Exceptions;

namespace MusicApp.Users.Exceptions
{
    public class UserNotFoundException : MusicException
    {
        public UserNotFoundException() : base("Nie znaleziono użytkownika.")
        {
        }
    }
}