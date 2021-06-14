using System;
using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.Users.CreateUser;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Users
{
    [Collection("IntegrationTests")]
    public class CreateUserTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldCreateNewUser()
        {
            await AddRoleAsync();
            var password = "Test12345!";
            var email = "test@test.test";
            var userName = "Test User";
            var command = new CreateUserCommand(password, email, userName);

            var userId = await SendAsync(command);

            var user = await GetApplicationUserAsync(userId);
            user.Should().NotBeNull();
            user.Email.Should().Be(email);
            user.UserName.Should().Be(userName);
        }

        [Fact]
        public async Task ShouldNotCreateInvalidUser()
        {
            await AddRoleAsync();
            var invalidPassword = "test";
            var email = "test@test.test";
            var userName = "Test User";
            var command = new CreateUserCommand(invalidPassword, email, userName);

            Func<Task<string>> creatingInvalidUser = async() => await SendAsync(command);

            creatingInvalidUser.Should().Throw<InvalidOperationException>();
        }
    }
}
