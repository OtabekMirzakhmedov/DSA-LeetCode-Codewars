namespace Codewars.ConstructingCar.Interfaces;

public interface IDrivingProcessor
{
    int ActualSpeed { get; }

    void IncreaseSpeedTo(int speed);

    void ReduceSpeed(int speed);
}