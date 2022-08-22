using FgfsInteraction;

var cancellationTokenSource = new CancellationTokenSource();

Console.CancelKeyPress += delegate
{
    cancellationTokenSource.Cancel();
};

var simulator = new Simulator();
var config = new FlightGearManagerConfiguration(49001, 49000);

using var flightGearManager = new FlightGearManager(simulator, config);
await flightGearManager.Run(cancellationTokenSource.Token);
