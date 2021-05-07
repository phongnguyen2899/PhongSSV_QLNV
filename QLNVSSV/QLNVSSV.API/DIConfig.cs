using Microsoft.Extensions.DependencyInjection;
using QLNVSSV.DATA.Database;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.DATA.Repository;

namespace QLNVSSV.API
{
    public static class DIConfig
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDatabaseContext<>), typeof(DatabaseContext<>));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IMailContentRepository, MailContentRepository>();
        }
    }
}
