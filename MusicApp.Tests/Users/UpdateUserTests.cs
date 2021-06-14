using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.IdentityData;
using MusicApp.Users.UpdateUser;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Users
{
    [Collection("IntegrationTests")]
    public class UpdateUserTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldUpdateExistingUser()
        {
            var originalUser = new ApplicationUser
            {
                Email = "original@original.original",
                UserName = "Original User",
                EmailConfirmed = true
            };

            var userId = await AddApplicationUserAsync(originalUser);
            var modifiedPassword = "Modified12345!";
            var modifiedEmail = "modified@modified.modified";
            var modifiedUserName = "Modified User";
            var modifiedEmailConfirmed = false;

            var command = new UpdateUserCommand(userId, modifiedUserName, modifiedEmail, modifiedEmailConfirmed, modifiedPassword);
            await SendAsync(command);

            var modifiedUser = await GetApplicationUserAsync(userId);
            modifiedUser.Should().NotBeNull();
            modifiedUser.Email.Should().Be(modifiedEmail);
            modifiedUser.UserName.Should().Be(modifiedUserName);
            modifiedUser.EmailConfirmed.Should().Be(modifiedEmailConfirmed);
        }
    }
}
