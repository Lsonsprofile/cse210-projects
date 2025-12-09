using System;

public class Running : Activity
{
    private double _distance; // in miles

    public Running(string date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
        => Math.Round((_distance / LengthInMinutes) * 60, 1);

    public override double GetPace()
        => Math.Round(LengthInMinutes / _distance, 2);
}