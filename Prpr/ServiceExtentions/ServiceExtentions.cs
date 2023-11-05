
using Prpr.Interfaces.SubjectInterfaces;
using static Prpr.Interfaces.SubjectInterfaces.ISubjectService;
namespace Prpr.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();
            return services;
        }
    }
}
