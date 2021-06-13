using System.Collections.Generic;
using MediatR;

namespace MusicApp.Users.GetUsers
{
    public class GetUsersQuery : IRequest<IReadOnlyList<UserDto>>
    {
    }
}