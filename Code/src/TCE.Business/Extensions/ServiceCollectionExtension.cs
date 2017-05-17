using Microsoft.Extensions.DependencyInjection;

namespace TCE.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTCEBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<EntityService>();
            // add here dependencies that will be used on the system
            return services;//.AddSingleton<,>();
        }
    }
}
