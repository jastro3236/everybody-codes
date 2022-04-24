using EverybodyCodes.Model;
using System.Text.RegularExpressions;

namespace EverybodyCodes.Logic.Utils
{
    public static class CameraMapper
    {
        private static readonly string _numberRegexPatter = "(UTR-CM-)(\\d+)";
        public static CameraDTO MapToDTO(this CameraModel cameraModel)
        {
            var reg = new Regex(_numberRegexPatter);
            var match = reg.Match(cameraModel.Camera);
            if (match.Success)
            {
                var cameraNumberString = match.Groups[2].Value;
                if (int.TryParse(cameraNumberString, out var cameraNumber))
                {
                    return new CameraDTO(
                    cameraNumber,
                    cameraModel.Camera,
                    cameraModel.Latitude,
                    cameraModel.Longitude);
                }
            }

            throw new CameraValidationException($"Cannot parse camera nmber: {cameraModel.Camera}");
        }
    }
}
