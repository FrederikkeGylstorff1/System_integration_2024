using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace SSEExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    [ApiController]
    [Route("[controller]")]
    public class SSEController : ControllerBase
    {
        [HttpGet]
        [Route("/events")]
        public async Task Events(CancellationToken cancellationToken)
        {
            Response.Headers.Add("Content-Type", "text/event-stream");

            for (int i = 0; !cancellationToken.IsCancellationRequested; i++)
            {
                // Construct the event data
                var eventData = $"data: This is event {i}\n\n";

                // Write the event data to the response stream
                await Response.WriteAsync(eventData);

                // Flush the response stream to ensure data is sent immediately
                await Response.Body.FlushAsync();

                // Wait for some time before sending the next event
                await Task.Delay(1000);
            }
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

