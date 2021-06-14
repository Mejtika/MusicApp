using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.IdentityData;
using MusicApp.Users.GetUsers;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Users
{
    [Collection("IntegrationTests")]
    public class GetUsersTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldGetUser()
        {
            var user = new ApplicationUser
            {
                UserName = "Test User",
                Email = "test@test.test"
            };
            await AddRoleAsync();
            await AddApplicationUserAsync(user);

            var result = await SendAsync(new GetUsersQuery());

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }
    }
}
