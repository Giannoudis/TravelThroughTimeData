namespace TravelThroughTimeData;

public class ValuePeriod
{
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime End { get; set; } = DateTime.MaxValue;

    public ValuePeriod()
    {
    }

    public ValuePeriod(DateTime start) :
        this(start, DateTime.MaxValue)
    {
    }

    public ValuePeriod(DateTime start, DateTime end)
    {
        Start = start < end ? start : end;
        End = start < end ? end : start;
    }

    public override string ToString() =>
        End == DateTime.MaxValue ?
            $"{Start.ToCompactString()}-open" :
            $"{Start.ToCompactString()}-{End.ToCompactString()}";
}
