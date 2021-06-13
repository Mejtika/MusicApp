using MediatR;

namespace MusicApp.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public string Id { get; }

        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}