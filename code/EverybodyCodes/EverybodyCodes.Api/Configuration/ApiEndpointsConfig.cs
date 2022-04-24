namespace EverybodyCodes.Api.Configuration
{
    public static class ApiEndpointsConfig
    {
        public static void AddEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.AddCamerasEndpoints();
        }
    }
}
