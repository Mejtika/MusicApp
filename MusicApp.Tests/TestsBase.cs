using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MusicApp.IdentityData;
using MusicApp.MusicData;
using Respawn;
using Xunit;

namespace MusicApp.Tests
{
    public abstract class IntegrationTestBase : IAsyncLifetime
    {
        public virtual async Task InitializeAsync()
        {
            await TestsBase.ResetCheckpoint().ConfigureAwait(false);
        }

        public virtual Task DisposeAsync() => Task.CompletedTask;
    }

    public class TestsBase
    {
        private static readonly IServiceScopeFactory _scopeFactory;

        private static readonly IConfiguration _configuration;

        private static readonly Checkpoint _checkpoint;

        static TestsBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.tests.json", false, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
            var startup = new Startup(_configuration);
            var services = new ServiceCollection();

            // Identity services need this.
            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "MusicApp"));
            startup.ConfigureServices(services);
            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__IdentityMigrationsHistory", "__IdentityMigrationsHistory" }
            };
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
            EnsureDatabase();
        }

        public static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var identityContext = scope.ServiceProvider.GetService<IdentityDbContext>();
            identityContext.Database.Migrate();

            var musicContext = scope.ServiceProvider.GetService<MusicDataDbContext>();
            musicContext.Database.Migrate();
        }

        public static Task ResetCheckpoint() => _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));

        public static async Task<string> AddApplicationUserAsync(ApplicationUser user)
        {
            using var scope = _scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            await userManager.CreateAsync(user).ConfigureAwait(false);
            return user.Id;
        }

        public static async Task<ApplicationUser> GetApplicationUserAsync(string userId)
        {
            using var scope = _scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            return await userManager.FindByIdAsync(userId).ConfigureAwait(false);
        }

        public static async Task AddRoleAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<MusicDataDbContext>();

            await context.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public static async Task AddRangeAsync<TEntity>(List<TEntity> entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<MusicDataDbContext>();

            await context.AddRangeAsync(entity);

            await context.SaveChangesAsync();
        }
    }
}
