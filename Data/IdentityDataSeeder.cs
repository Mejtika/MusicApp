using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicApp.Models;

namespace MusicApp.Data
{
    namespace Servibes.Bootstrapper.Data
    {
        public class IdentityDataSeeder
        {
            private const string AdminRole = "Admin";
            private const string UserRole = "User";
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public IdentityDataSeeder(
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task SeedAsync()
            {
                var adminPassword = "Admin12345!";
                var businessUser = new ApplicationUser
                {
                    Id = "b8633e2d-a33b-45e6-8329-1958b3252bbd",
                    UserName = "business@business.pl",
                    NormalizedUserName = "BUSINESS@BUSINESS.PL",
                    Email = "business@business.pl",
                    NormalizedEmail = "BUSINESS@BUSINESS.PL",
                    EmailConfirmed = true,
                };

                var userPassword = "User12345!";
                var clientUser = new ApplicationUser
                {
                    Id = "3f396b9a-37b7-11eb-adc1-0242ac120002",
                    UserName = "client@client.pl",
                    NormalizedUserName = "CLIENT@CLIENT.PL",
                    Email = "client@client.pl",
                    NormalizedEmail = "CLIENT@CLIENT.PL",
                    EmailConfirmed = true
                };

                await CreateUserAsync(businessUser, adminPassword);
                await CreateUserAsync(clientUser, userPassword);

                var adminInRole = await _userManager.IsInRoleAsync(businessUser, AdminRole);
                if (!adminInRole)
                    await _userManager.AddToRoleAsync(businessUser, AdminRole);

                var userInRole = await _userManager.IsInRoleAsync(clientUser, UserRole);
                if (!userInRole)
                    await _userManager.AddToRoleAsync(clientUser, UserRole);

            }

            private async Task CreateUserAsync(ApplicationUser user, string password)
            {
                var exists = await _userManager.FindByEmailAsync(user.Email);
                if (exists == null)
                {
                    var result = await _userManager.CreateAsync(user, password);
                }
            }
        }

        public class SetupIdentityDataSeeder : IHostedService
        {
            private readonly IServiceProvider _serviceProvider;
            public SetupIdentityDataSeeder(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }

            public async Task StartAsync(CancellationToken cancellationToken)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<IdentityDataSeeder>();

                    await seeder.SeedAsync();
                }
            }

            public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        }
    }

}
