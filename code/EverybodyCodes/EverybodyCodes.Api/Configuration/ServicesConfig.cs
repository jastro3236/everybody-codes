using EverybodyCodes.Logic;

namespace EverybodyCodes.Api.Configuration
{
    public static class ServicesConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICameraService, CameraService>();
        }
    }
}
