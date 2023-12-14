using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TestEliteFlower.Domain.Interfaces;
using TestEliteFlower.Infraestructure.Repository;
using TestEliteFlower;
using Microsoft.AspNetCore.Hosting;

namespace TestEliteFlower
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, ApplicationDbContextUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(ApplicationDbContextRepository<>));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddCors(options => {
                options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            return services;
        }
    }
}
