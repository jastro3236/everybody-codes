using EverybodyCodes.Model;

namespace EverybodyCodes.Logic
{
    public interface ICameraService
    {
        Task<IList<CameraDTO>> GetCameras(string? filter = null);
        Task<CameraDTO?> GetCameraByName(string cameraName);
    }
}