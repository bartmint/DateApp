using DateApp.Domain;
using DateApp.Domain.Abstract;
using DateApp.Infrastructure.Data;
using DateApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateApp.Infrastructure
{
    public static class ServiceDi
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPhotoService, PhotoRepository>();
            services.AddTransient<IPhotoGet,PhotoRepository>();
            services.AddTransient<ILikesRepository, LikesRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();


            return services;
        }
    }
}
