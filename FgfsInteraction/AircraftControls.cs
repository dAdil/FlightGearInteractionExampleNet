using LanguageExt;

namespace FgfsInteraction;

public record AircraftControls(
    double ThrottlePercent,
    double ElevatorPercent,
    double AileronPercent,
    double RudderPercent
    );

public static class AircraftControlsFactory
{
    public static Option<AircraftControls> FromInputString(string input) =>
        input
            .Split(",")
            .Select(TryParse)
            .Sequence()
            .Select(enumerable => enumerable.ToArray())
            .Where(arr => arr.Length == 4)
            .Select(arr => new AircraftControls(arr[0], arr[1], arr[2], arr[3]));

    private static Option<double> TryParse(string input)
    {
        if (double.TryParse(input, out double value))
            return value;

        return Option<double>.None;
    }
}
