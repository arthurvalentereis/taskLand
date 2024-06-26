using Microsoft.EntityFrameworkCore;
using TaskLand.API.Data.Contexts;
using TaskLand.API.Data.Repositories;
using TaskLand.API.Data.Repositories.Base;
using TaskLand.API.Interfaces.Mappers;
using TaskLand.API.Interfaces.Repositories;
using TaskLand.API.Interfaces.Repositories.Base;
using TaskLand.API.Interfaces.Services;
using TaskLand.API.Services;

namespace TaskLand.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.RegisterData(configuration);
            services.RegisterRepositories();
            services.RegisterServices();
            return services;
        }

        private static IServiceCollection RegisterData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(x => x
                           .UseSqlServer(configuration["ConnectionStrings:Task"], x => { x.CommandTimeout(60); }));
            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskService,TaskService >();
            services.AddTransient<ITaskMapperService, TaskMapperService>();

            return services;
        }
    }
}
