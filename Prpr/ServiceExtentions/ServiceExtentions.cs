
using Prpr.Interfaces.StudentInterfaces;
using static Prpr.Interfaces.StudentInterfaces.IStudentService;
namespace Prpr.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
