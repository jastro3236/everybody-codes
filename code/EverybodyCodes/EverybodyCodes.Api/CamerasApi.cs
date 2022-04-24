using EverybodyCodes.Logic;
using Microsoft.AspNetCore.Mvc;

namespace EverybodyCodes.Api
{
    public static class CamerasApi
    {
        public static void AddCamerasEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/cameras", GetCameras);
            endpoints.MapGet("/api/camera", GetCamera);

        }

        private static async Task<IResult> GetCameras(HttpContext context, ICameraService cameraService)
        {
            try
            {
                var cameras = await cameraService.GetCameras();
                return Results.Ok(cameras);
            }
            catch (Exception e)
            {

                return Results.BadRequest(e);
            }
        }

        private static async Task<IResult> GetCamera(HttpContext context, ICameraService cameraService, [FromQuery] string cameraName)
        {
            try
            {
                var camera = await cameraService.GetCameraByName(cameraName);
                return Results.Ok(camera);
            }
            catch (Exception e)
            {

                return Results.BadRequest(e);
            }
        }
    }
}
