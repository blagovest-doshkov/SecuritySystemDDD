namespace SecuritySystem.Infrastructure
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Application.Identity;
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.Guards.Services;
    using SecuritySystem.Infrastructure.Common;
    using SecuritySystem.Infrastructure.Common.Events;
    using SecuritySystem.Infrastructure.Common.Persistence;
    using SecuritySystem.Infrastructure.ControlCenter;
    using SecuritySystem.Infrastructure.Guards;
    using SecuritySystem.Infrastructure.Guards.Services;
    using SecuritySystem.Infrastructure.Identity;
    using SecuritySystem.Infrastructure.Systems;
    using System.Text;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddIdentity(configuration)
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddTransient<ILocationGuardPatrolService, LocationGuardPatrolService>();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<SecuritySystemDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(SecuritySystemDbContext).Assembly.FullName)))
                .AddScoped<IAlarmSystemsDbContext>(provider => provider.GetService<SecuritySystemDbContext>())
                .AddScoped<IGuardsDbContext>(provider => provider.GetService<SecuritySystemDbContext>())
                .AddScoped<IControlCenterDbContext>(provider => provider.GetService<SecuritySystemDbContext>())
                .AddTransient<IInitializer, DatabaseInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>))
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

        private static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<SecuritySystemDbContext>();

            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddTransient<IIdentity, IdentityService>();
            services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();

            return services;
        }
    }
}
