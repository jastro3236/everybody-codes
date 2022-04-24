using CsvHelper;
using CsvHelper.Configuration;
using EverybodyCodes.Model;
using System.Globalization;
using System.Text;

namespace EverybodyCodes.Persistence.CSV
{
    public class CSVReader : ICSVReader
    {
        public async Task<IList<CameraModel>> GetCamerasFromCsv()
        {
            var locationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            using var reader = new StreamReader($"{locationPath}/cameras-defb.csv");

            var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = ";",
                Encoding = Encoding.Default,
                BadDataFound = null
            };
            using var csv = new CsvReader(reader, csvConfiguration);
            await csv.ReadAsync();
            csv.ReadHeader();

            var cameras = new List<CameraModel>();

            while (await csv.ReadAsync())
            {
                try
                {
                    csv.TryGetField(nameof(CameraModel.Camera), out string camera);
                    csv.TryGetField(nameof(CameraModel.Latitude), out decimal latitude);
                    csv.TryGetField(nameof(CameraModel.Longitude), out decimal longitude);

                    var cameraModel = new CameraModel(camera, latitude, longitude);

                    if (cameraModel.Latitude is not 0 && cameraModel.Longitude is not 0)
                    {
                        cameras.Add(cameraModel);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return cameras;
        }
    }
}
