using EverybodyCodes.Model;

namespace EverybodyCodes.Persistence.CSV
{
    public interface ICSVReader
    {
        Task<IList<CameraModel>> GetCamerasFromCsv();
    }
}
