using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Models.Repositories;

namespace Tasks.Models
{
    public static class ServiceRegistration
    {
        public static void AddModelServices(this IServiceCollection services)
        {
            // services.AddSingleton<ITaskRepository, TaskRepository>();
            // Register services here
        }
    }
}
