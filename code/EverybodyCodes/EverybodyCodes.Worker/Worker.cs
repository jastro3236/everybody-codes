using CommandLine;
using EverybodyCodes.Logic;

namespace EverybodyCodes.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHost _host;
        private readonly ICameraService _cameraService;

        public Worker(ILogger<Worker> logger, IHost host, ICameraService cameraService)
        {
            _logger = logger;
            _host = host;
            _cameraService = cameraService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string[] arguments = Environment.GetCommandLineArgs();
            Parser.Default.ParseArguments<CLIArguments>(arguments)
                    .WithParsed(async cli =>
                    {
                        if (string.IsNullOrWhiteSpace(cli.SearchName))
                        {
                            _logger.LogWarning("--n --name parameter is reqired");
                            await _host.StopAsync(stoppingToken);
                        }
                        else
                        {
                            try
                            {
                                _logger.LogInformation($"Executing search by name {cli.SearchName}");

                                var cameras = await _cameraService.GetCameras(cli.SearchName);

                                _logger.LogInformation($"Found {cameras.Count} cameras");
                                foreach (var camera in cameras)
                                {
                                    var message = $"{camera.Number} | {camera.Camera} | {camera.Latitude} | {camera.Longitude}";
                                    Console.WriteLine(message);
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError($"Exception occured while searching the data." + ex.Message);
                            }
                        }
                    });
        }
    }
}
