using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StatlerWaldorfCorp.ProximityMonitor.Queues;
using StatlerWaldorfCorp.ProximityMonitor.Realtime;
using RabbitMQ.Client.Events;
using StatlerWaldorfCorp.ProximityMonitor.Events;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using StatlerWaldorfCorp.ProximityMonitor.TeamService;

namespace StatlerWaldorfCorp.ProximityMonitor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();


            services.Configure<QueueOptions>(Configuration.GetSection("QueueOptions"));
            services.Configure<PubnubOptions>(Configuration.GetSection("PubnubOptions"));
            services.Configure<TeamServiceOptions>(Configuration.GetSection("teamservice"));
            services.Configure<AMQPOptions>(Configuration.GetSection("amqp"));
            

            services.AddTransient(typeof(IAMQPConnectionFactory), typeof(AMQPConnectionFactory));
            services.AddTransient(typeof(EventingBasicConsumer), typeof(RabbitMQEventingConsumer));
            services.AddSingleton(typeof(IEventSubscriber), typeof(RabbitMQEventSubscriber));
            services.AddSingleton(typeof(IEventProcessor), typeof(ProximityDetectedEventProcessor));
            services.AddTransient(typeof(ITeamServiceClient), typeof(HttpTeamServiceClient));

            services.AddRealtimeService();
            services.AddSingleton(typeof(IRealtimePublisher), typeof(PubnubRealtimePublisher));
        }

        // Singletons are lazy instantiation.. so if we don't ask for an instance during startup,
        // they'll never get used.
        public void Configure(IApplicationBuilder app,
                IWebHostEnvironment env,
                IEventProcessor eventProcessor,
                IOptions<PubnubOptions> pubnubOptions,
                IRealtimePublisher realtimePublisher)
        {
            realtimePublisher.Validate();
            realtimePublisher.Publish(pubnubOptions.Value.StartupChannel, "{'hello': 'world'}");

            eventProcessor.Start();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
               endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller}/{action}/{id?}"
                   );
           });
        }
    }
}