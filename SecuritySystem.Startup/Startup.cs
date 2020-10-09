namespace SecuritySystem.Startup
{
    using Application;
    using Domain;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDomain()
                .AddInfrastructure(this.Configuration)
                .AddApplication(this.Configuration)
                ;

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.Initialize();

            //app
            //    .UseValidationExceptionHandler()
            //    .UseHttpsRedirection()
            //    .UseRouting()
            //    .UseCors(options => options
            //        .AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod())
            //    .UseAuthentication()
            //    .UseAuthorization()
            //    .UseEndpoints(endpoints => endpoints
            //        .MapControllers())
            //    .Initialize();
        }
    }
}
