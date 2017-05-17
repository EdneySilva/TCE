using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TCE.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // add here dependencies that will be used on the system
            return services;//.AddSingleton<,>();
        }
    }
}
