using Microsoft.Extensions.DependencyInjection;
using Tasks.Models.Repositories;
using Tasks.UseCases.Services;

namespace Tasks.UseCases
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();

        }
    }
}
