using DateApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;
using DateApp.Domain.Abstract;
using DateApp.Infrastructure.Repositories;

namespace DateApp.Domain
{
    public static class ServiceDi
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
