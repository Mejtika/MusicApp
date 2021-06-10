using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;

namespace MusicApp.Users.GetUsers
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Select(user => new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.EmailConfirmed
            }).ToListAsync(cancellationToken);

            var usersDto = users.Select(user =>
                new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed
                }).ToList();

            return usersDto;
        }
    }
}
