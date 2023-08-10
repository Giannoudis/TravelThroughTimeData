namespace TravelThroughTimeData;

public class TimeValue<T>
{
    public DateTime Created { get; set; }
    public ValuePeriod Period { get; set; }
    public T Value { get; set; }

    public TimeValue(DateTime created, ValuePeriod period, T value)
    {
        Created = created;
        Period = period;
        Value = value;
    }

    public override string ToString() =>
        $"Created = {Created.ToCompactString()} | period = {Period} | value = {Value}";
}
