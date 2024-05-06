using ASPNET_MVC.Business.Interfaces;
using ASPNET_MVC.Business.Services;
using ASPNET_MVC.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNET_MVC.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IExportToExcelService, ExportToExcelService>();
            services.AddTransient<IPersonService, PersonService>();
        }
    }
}
