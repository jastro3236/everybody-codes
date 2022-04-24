
using EverybodyCodes.Model;
using EverybodyCodes.Persistence.CSV;

namespace EverybodyCodes.Persistence.Repository
{
    public class CameraRepository : ICameraRepository
    {
        private readonly ICSVReader _csvReader;
        public CameraRepository(ICSVReader csvReader)
        {
            _csvReader = csvReader;
        }

        public async Task<CameraModel?> GetCameraByName(string cameraName)
        {
            var cameras = await _csvReader.GetCamerasFromCsv();
            var camera = cameras.Where(c => c.Camera.Equals(cameraName)).SingleOrDefault();
            return camera;
        }

        public async Task<IList<CameraModel>> GetCameras(string? filter)
        {
            var cameras = await _csvReader.GetCamerasFromCsv();
            if (filter is not null)
            {
                cameras = cameras.Where(c => c.Camera.ToUpper().Contains(filter.ToUpper())).ToList();
            }
            return cameras;
        }
    }
}
