using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetcore_app
{
    public class  Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            app.Run(async (context)=>{
            var text = "<h1>Hello, World!</h1>";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            await context.Response.Body.WriteAsync(data, 0, data.Length);
            });
        }
    }
}