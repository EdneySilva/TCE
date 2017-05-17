using TCE.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTCERepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            return services;
        }
    }
}
