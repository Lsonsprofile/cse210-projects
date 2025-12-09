using System;

public class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
        => Math.Round(_speed * (LengthInMinutes / 60.0), 1);

    public override double GetSpeed() => Math.Round(_speed, 1);

    public override double GetPace()
        => Math.Round(60 / _speed, 2);
}