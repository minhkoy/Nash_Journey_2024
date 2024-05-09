using Microsoft.Extensions.DependencyInjection;
using Person.Service.Interfaces;
using Person.Service.Mappers;
using Person.Service.Services;
using System.Reflection;

namespace Person.Service
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }
    }
}
