using MediatR;

namespace MusicApp.Users.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Password { get; }

        public string Email { get; }

        public string UserName { get; }

        public CreateUserCommand(string password, string email, string userName)
        {
            Password = password;
            Email = email;
            UserName = userName;
        }
    }
}