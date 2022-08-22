namespace FgfsInteraction;

public record Position(
    double LatitudeDegrees,
    double LongitudeDegrees,
    double AltitudeFeet
    );

public record Orientation(
    double RollDegrees,
    double PitchDegrees,
    double YawDegrees
    );

public record AircraftState(
    Position Position,
    Orientation Orientation
    );

public static class AircraftStateExtensions
{
    public static string ToCommaSeparatedString(this AircraftState state) =>
        $"{state.Position.LatitudeDegrees}," +
        $"{state.Position.LongitudeDegrees}," +
        $"{state.Position.AltitudeFeet}," +
        $"{state.Orientation.RollDegrees}," +
        $"{state.Orientation.PitchDegrees}," +
        $"{state.Orientation.YawDegrees}" + 
        "\n";
}
