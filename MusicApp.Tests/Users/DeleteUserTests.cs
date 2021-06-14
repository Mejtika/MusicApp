using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.IdentityData;
using MusicApp.Users.DeleteUser;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Users
{
    [Collection("IntegrationTests")]
    public class DeleteUserTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldDeleteUser()
        {
            var user = new ApplicationUser
            {
                UserName = "Test User",
                Email = "test@test.test"
            };
            var userId = await AddApplicationUserAsync(user);

            await SendAsync(new DeleteUserCommand(userId));

            var result = await GetApplicationUserAsync(userId);
            result.Should().BeNull();
        }
    }
}
