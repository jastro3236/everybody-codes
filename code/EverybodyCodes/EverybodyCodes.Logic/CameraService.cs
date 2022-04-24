using EverybodyCodes.Logic.Utils;
using EverybodyCodes.Model;
using EverybodyCodes.Persistence.Repository;

namespace EverybodyCodes.Logic
{
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _cameraRepository;
        public CameraService(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }
        public async Task<CameraDTO?> GetCameraByName(string cameraName)
        {
            var camera = await _cameraRepository.GetCameraByName(cameraName);
            if (camera == null)
            {
                throw new CameraValidationException($"Cannot get camera with name {cameraName}");
            }
            return camera.MapToDTO();
        }

        public async Task<IList<CameraDTO>> GetCameras(string? filter)
        {
            var cameras = await _cameraRepository.GetCameras(filter);
            return cameras.Select(c => c.MapToDTO()).ToList();
        }

    }
}