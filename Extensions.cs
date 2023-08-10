namespace TravelThroughTimeData;

public static class Extensions
{
    /// <summary>
    /// Get compact date time string
    /// </summary>
    /// <param name="value">The date value</param>
    /// <returns>Compact date string</returns>
    public static string ToCompactString(this DateTime value) =>
        // test fro midnight
        value.TimeOfDay.Ticks == 0 ? $"{value:d}" : $"{value:g}";

    /// <summary>
    /// Test if moment is within the date period
    /// </summary>
    /// <param name="value">The time value</param>
    /// <param name="evaluationDate">The test moment</param>
    /// <returns></returns>
    public static bool IsInside<T>(this TimeValue<T> value, DateTime evaluationDate) =>
        evaluationDate >= value.Period.Start && evaluationDate <= value.Period.End;

    /// <summary>
    /// Get the time value for a specific evaluation date
    /// </summary>
    /// <param name="values">The time values</param>
    /// <param name="evaluationDate">The evaluation date</param>
    /// <returns>The time value for the evaluation date, null if no value was found</returns>
    public static TimeValue<T>? GetTimeValue<T>(this TimeField<T> values, DateTime evaluationDate)
    {
        if (!values.Any())
        {
            return default;
        }

        // remove outside periods
        var insideValues = values.Where(x => x.IsInside(evaluationDate)).ToList();
        if (!insideValues.Any())
        {
            return default;
        }

        // select the evaluated value (last created)
        var evaluationValue = insideValues.OrderByDescending(x => x.Created).First();
        return evaluationValue;
    }
}
