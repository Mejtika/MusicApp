using System;
using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.IdentityData;
using MusicApp.Users;
using MusicApp.Users.GetUser;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Users
{
    [Collection("IntegrationTests")]
    public class GetUserTests : IntegrationTestBase
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
            var userId = await AddApplicationUserAsync(user);

            var result = await SendAsync(new GetUserQuery(userId));

            result.Should().NotBeNull();
            result.UserName.Should().Be(user.UserName);
            result.Email.Should().Be(user.Email);
        }

        [Fact]
        public async Task ShouldThrowIfCantFindUser()
        {
            Func<Task<UserDto>> getNotExistingUser = async() => await SendAsync(new GetUserQuery("invalid_id"));

            getNotExistingUser.Should().Throw<InvalidOperationException>();
        }
    }
}
