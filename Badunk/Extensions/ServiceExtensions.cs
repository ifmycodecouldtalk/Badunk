﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Badunk.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
             services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy", builder =>
                 builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
             });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
             services.Configure<IISOptions>(options =>
             {
             });
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
             services.AddDbContext<RepositoryContext>(opts =>
             opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => 
                b.MigrationsAssembly("Badunk")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();


    }
}
