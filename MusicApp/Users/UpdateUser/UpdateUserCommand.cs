using MediatR;

namespace MusicApp.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string Id { get; }

        public string UserName { get; }

        public string Email { get; }

        public bool EmailConfirmed { get; }

        public string Password { get; }

        public UpdateUserCommand(string id, string userName, string email, bool emailConfirmed, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            EmailConfirmed = emailConfirmed;
            Password = password;
        }
    }
}