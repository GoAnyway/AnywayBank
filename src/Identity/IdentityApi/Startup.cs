using IdentityApi.Utils.Extensions.ApplicationBuilderExtensions;
using IdentityApi.Utils.Extensions.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi
{
    internal class Startup
    {
        public Startup(IConfiguration configuration) => 
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSettings(Configuration)
                .AddDbContexts(Configuration)
                .AddRepositories()
                .AddCoreServices()
                .AddAutoMapper()
                .AddMessageBus(Configuration)
                .AddControllers();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder appBuilder) =>
            appBuilder
                .UseMiddlewares()
                .UseRouting()
                .UseEndpoints(_ => _.MapControllers());
    }
}
