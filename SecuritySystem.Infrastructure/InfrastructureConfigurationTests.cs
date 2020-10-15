using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecuritySystem.Application.Common;
using SecuritySystem.Application.Systems.Querries;
using SecuritySystem.Domain.Common;
using SecuritySystem.Domain.Systems.Models;
using SecuritySystem.Domain.Systems.Repositories;
using SecuritySystem.Infrastructure.Common;
using SecuritySystem.Infrastructure.Common.Events;
using SecuritySystem.Infrastructure.Common.Persistence;
using SecuritySystem.Infrastructure.ControlCenter;
using SecuritySystem.Infrastructure.Guards;
using SecuritySystem.Infrastructure.Systems;
using System;

namespace SecuritySystem.Infrastructure
{
    [TestClass]
    public class InfrastructureConfigurationTests
    {
        [TestMethod]
        public void TestRepositoryConfiguration()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDbContext<SecuritySystemDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IAlarmSystemsDbContext>(provider => provider.GetService<SecuritySystemDbContext>())
                .AddScoped<IGuardsDbContext>(provider => provider.GetService<SecuritySystemDbContext>())
                .AddScoped<IControlCenterDbContext>(provider => provider.GetService<SecuritySystemDbContext>())
                .AddTransient<IInitializer, DatabaseInitializer>()
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            Assert.IsNotNull(services
                .GetService<IAlarmSystemDomainRepository>());
        }
    }
}
