using System.Net.Sockets;

namespace FgfsInteraction;

public record FlightGearManagerConfiguration(int FlightGearOutputPort, int FlightgearInputPort);

public class FlightGearManager : IDisposable
{
    private readonly ISimulator simulator;

    private readonly UdpClient readerClient;
    private readonly UdpClient writerClient;
    private readonly FlightGearManagerConfiguration configuration;

    public FlightGearManager(ISimulator simulator, FlightGearManagerConfiguration configuration)
    {
        this.simulator = simulator;
        this.configuration = configuration;

        readerClient = new UdpClient(configuration.FlightGearOutputPort);
        writerClient = new UdpClient(configuration.FlightgearInputPort);
    }

    public async Task Run(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            var controlString = await readerClient.ReceiveAsciiStringAsync(ct);
            var aircraftControls = AircraftControlsFactory.FromInputString(controlString);

            await aircraftControls.IfSomeAsync(async controls =>
            {
                var aircraftStateString = simulator
                    .UpdateState(controls)
                    .ToCommaSeparatedString();

                await writerClient.SendAsciiStringAsync(aircraftStateString, "127.0.0.1", configuration.FlightgearInputPort, ct);
            });

            // This is pretty hacky. Would be better to run the this and the simulation on independent schedules
            // Especially if the simulator is sensitive to time step.
            await Task.Delay(5);
        }
    }

    public void Dispose()
    {
        readerClient.Dispose();
        writerClient.Dispose();
    }
}
