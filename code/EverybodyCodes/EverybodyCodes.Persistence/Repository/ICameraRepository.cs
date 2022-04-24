
using EverybodyCodes.Model;

namespace EverybodyCodes.Persistence.Repository
{
    public interface ICameraRepository
    {
        Task<IList<CameraModel>> GetCameras(string? filter = null);
        Task<CameraModel?> GetCameraByName(string cameraName);
    }
}
