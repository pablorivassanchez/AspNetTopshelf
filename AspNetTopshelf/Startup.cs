using AspNetTopshelf.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetTopshelf
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddScoped<IJob, DumbJob>();

            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire");

            app.UseHangfireServer();

            HangfireJobScheduler.ScheduleRecurringJobs();

            app.UseMvc();
        }
    }
}
