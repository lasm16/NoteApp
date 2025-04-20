using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddDbContext<AppContext>(x =>
            {
                x.UseNpgsql("UserName=postgres;Password=postgres;Host=localhost;Port=5432;Database=NoteDb;");
            });
            return services;
        }
    }
}
