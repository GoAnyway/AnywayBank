using AnywayBankApi.Utils.Extensions.ApplicationBuilderExtensions;
using AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions;
using CommonUtils.Extensions.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi
{
    internal class Startup
    {
        public Startup(IConfiguration configuration) => 
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSettings(Configuration)
                .AddDbContexts(Configuration)
                .AddRepositories()
                .AddCoreServices()
                .AddAutoMapper()
                .AddMessageBus(Configuration)
                .AddJwtAuthentication(Configuration)
                .AddControllers();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder appBuilder) =>
            appBuilder
                .UseMiddlewares()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(_ => _.MapControllers());
    }
}