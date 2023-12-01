using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Services.JsonPlaceHolder;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("UserManagementConnectionString"), b => b.MigrationsAssembly("UserManagement.Api")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJsonPlaceholderClient, JsonPlaceholderClient>();
            return services;
        }
    }
}
