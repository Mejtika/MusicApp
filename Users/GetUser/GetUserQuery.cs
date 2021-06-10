using MediatR;

namespace MusicApp.Users.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string Id { get; }

        public GetUserQuery(string id)
        {
            Id = id;
        }
    }
}