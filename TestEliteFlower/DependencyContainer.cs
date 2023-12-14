﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestEliteFlower.Domain.Interfaces;
using TestEliteFlower.Infraestructure.Repository;

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
