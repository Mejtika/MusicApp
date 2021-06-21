using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.IdentityData;
using MusicApp.Users.Exceptions;

namespace MusicApp.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is not { })
            {
                throw new UserNotFoundException();
            }

            var deletionResult = await _userManager.DeleteAsync(user);
            if (!deletionResult.Succeeded)
            {
                throw new InvalidUserDataException("Próba usunięcia użytkownika nie powiodła się");
            }

            return Unit.Value;
        }
    }
}
