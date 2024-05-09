using Microsoft.Extensions.DependencyInjection;
using Person.Model.Repositories;

namespace Person.Model
{
    public static class ServiceRegistration
    {
        public static void AddModelServices(this IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
