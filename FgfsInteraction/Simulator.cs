namespace FgfsInteraction;

public interface ISimulator
{
    AircraftState UpdateState(AircraftControls controls);
}

public class Simulator : ISimulator
{
    public AircraftState UpdateState(AircraftControls controls) =>
        new AircraftState(
            new Position(0, 0, 1000),
            new Orientation(controls.AileronPercent * 100, controls.ElevatorPercent * -100, controls.RudderPercent * 100)
            );
}
