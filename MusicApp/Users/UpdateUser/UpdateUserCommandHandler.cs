using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.IdentityData;
using MusicApp.Users.Exceptions;

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
                throw new UserNotFoundException();
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                var updateEmailResult = await _userManager.SetEmailAsync(user, request.Email);
                if (!updateEmailResult.Succeeded)
                {
                    throw new InvalidUserDataException("Próba aktualizacji adresu email nie powiodła się.");
                }
            }

            if (request.EmailConfirmed != user.EmailConfirmed)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, emailToken);
                if (!confirmEmailResult.Succeeded)
                {
                    throw new InvalidUserDataException("Próba aktywacji adresu email nie powiodła się.");
                }
            }

            if (!string.IsNullOrEmpty(request.UserName))
            {
                var updateEmailResult = await _userManager.SetUserNameAsync(user, request.UserName);
                if (!updateEmailResult.Succeeded)
                {
                    throw new InvalidUserDataException("Próba aktualizacji nicku nie powiodła się.");
                }
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var updatePasswordResult = await _userManager.ResetPasswordAsync(user, passwordToken, request.Password);
                if (!updatePasswordResult.Succeeded)
                {
                    throw new InvalidUserDataException("Próba aktualizacji hasła nie powiodła się.");
                }
            }

            return Unit.Value;
        }
    }
}
