// TODO: Treat case when all elevations are equal (0,0,0,... or 1,1,1,...).

var terrainElevations = new int[] { 2, 1, 0, 4, 3, 2, 1, 1, 3, 5, 2, 1, 4, 2, 4, 1, 2, 2, 3, 4 };

int GetWaterVolume(int[] elevations)
{
    if (elevations.Length < 1)
        throw new ArgumentException("Elevations array was empty.");

    if (elevations.Any(e => e < 0))
        throw new ArgumentException("Elevations array contains negative elevation values, which are not supported at the moment.");

    var peaks = GetPeaks(elevations);

    if (peaks.Count <= 1)
        return 0;

    int waterVolume = 0;

    for (int i = 0; i < peaks.Count; i++)
    {
        var leftPeak = peaks[i];

        if (i + 1 < peaks.Count)
        {
            var rightPeak = peaks[i + 1];

            var smallestElev = Math.Min(leftPeak.Elev, rightPeak.Elev);

            for (int j = leftPeak.Index + 1; j < rightPeak.Index; j++)
            {
                waterVolume += smallestElev - elevations[j];
            }
        }
    }

    return waterVolume;
}

List<Elevation> GetPeaks(int[] elevations)
{
    var peaks = new List<Elevation>();

    if (elevations.Length < 1)
        return peaks;

    if (elevations.Length == 1)
    {
        peaks.Add(new Elevation() { Index = 0, Elev = elevations[0] });
        return peaks;
    }

    int lastIndex = elevations.Length - 1;

    for (int i = 0; i < elevations.Length; i++)
    {
        var elev = elevations[i];

        if (i == 0 && elevations[i + 1] < elev)
        {
            var peak = new Elevation() { Index = i, Elev = elev };
            peaks.Add(peak);
        }
        else if (i == lastIndex && elevations[i - 1] < elev)
        {
            var peak = new Elevation() { Index = i, Elev = elev };
            peaks.Add(peak);
        }
        else if (i > 0 && elevations[i - 1] <= elev && elevations[i + 1] < elev)
        {
            var peak = new Elevation() { Index = i, Elev = elev };
            peaks.Add(peak);
        }
    }

    return peaks;
}

Console.WriteLine("Peaks for {0} are:", string.Join(", ", terrainElevations));

var peaks = GetPeaks(terrainElevations);

foreach (var peak in peaks)
{
    Console.WriteLine(peak);
}

var waterVolume = GetWaterVolume(terrainElevations);

Console.WriteLine("Water volume held is {0}", waterVolume);

public record Elevation
{
    public int Index = 0;
    public int Elev = 0;
}