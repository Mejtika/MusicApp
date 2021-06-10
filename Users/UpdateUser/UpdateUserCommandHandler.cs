using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Models;
using MusicApp.Users.CreateUser;

namespace MusicApp.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user is not { })
            {
                throw new InvalidOperationException("User don't exist");
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                var updateEmailResult = await _userManager.SetEmailAsync(user, request.Email);
                if (!updateEmailResult.Succeeded)
                {
                    throw new InvalidOperationException("Cannot update user's email");
                }
            }

            if (!string.IsNullOrEmpty(request.UserName))
            {
                var updateEmailResult = await _userManager.SetUserNameAsync(user, request.UserName);
                if (!updateEmailResult.Succeeded)
                {
                    throw new InvalidOperationException("Cannot update user's userName");
                }
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var updatePasswordResult = await _userManager.ResetPasswordAsync(user, token, request.Password);
                if (!updatePasswordResult.Succeeded)
                {
                    throw new InvalidOperationException("Cannot update user's password");
                }
            }

            return Unit.Value;
        }
    }
}
