using EverybodyCodes.Persistence.CSV;
using EverybodyCodes.Persistence.Repository;

namespace EverybodyCodes.Api.Configuration
{
    public static class RepositoriesConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICameraRepository, CameraRepository>();
            services.AddScoped<ICSVReader, CSVReader>();
        }
    }
}
