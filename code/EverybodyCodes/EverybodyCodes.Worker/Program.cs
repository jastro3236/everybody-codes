using EverybodyCodes.Logic;
using EverybodyCodes.Persistence.CSV;
using EverybodyCodes.Persistence.Repository;
using EverybodyCodes.Worker;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddSingleton<ICameraRepository, CameraRepository>();
        services.AddSingleton<ICSVReader, CSVReader>();
        services.AddSingleton<ICameraService, CameraService>();
    })
    .Build();

await host.RunAsync();
