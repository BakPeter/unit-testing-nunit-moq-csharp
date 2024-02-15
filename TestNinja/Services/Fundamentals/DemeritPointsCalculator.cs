namespace TestNinja.Services.Fundamentals;

public class DemeritPointsCalculator
{
    private readonly int SpeedLimit = 65;
    private readonly int MaxSpeed = 300;
    private readonly int MinSpeed = 1;
    public int CalculateDemeritPoints(int speed)
    {
        if (speed < MinSpeed || speed > MaxSpeed) throw new ArgumentOutOfRangeException();
        var overLimit = speed - SpeedLimit;
        if (overLimit <= 0) return 0;
        return overLimit / 5;
    }
}