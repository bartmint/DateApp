using DateApp.Domain.Abstract;
using DateApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateApp.Infrastructure
{
    public static class ServiceDi
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<ITokenRepository, TokenRepository>();
            return service;
        }
    }
}
