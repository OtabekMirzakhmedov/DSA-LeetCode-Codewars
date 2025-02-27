using Codewars.ConstructingCar.Interfaces;
using System;

namespace Codewars.ConstructingCar;

public class Car : ICar
{
    public IFuelTankDisplay fuelTankDisplay;

    private IEngine engine;

    private IFuelTank fuelTank;
    
    public IDrivingInformationDisplay drivingInformationDisplay; 

    private IDrivingProcessor drivingProcessor;

    public Car()
    {
        this.fuelTank = new FuelTank(20);
        this.engine = new Engine(this.fuelTank);
        this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
        this.drivingProcessor = new DrivingProcessor();
        this.drivingInformationDisplay = new DrivingInformationDisplay(this.drivingProcessor);
    }

    public Car(double fuelLevel)
    {
        this.fuelTank = new FuelTank(fuelLevel);
        this.engine = new Engine(this.fuelTank);
        this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
        this.drivingProcessor = new DrivingProcessor();
        this.drivingInformationDisplay = new DrivingInformationDisplay(this.drivingProcessor);
    }
    
    public Car(double fuelLevel, int maxAcceleration)
    {
        this.fuelTank = new FuelTank(fuelLevel);
        this.engine = new Engine(this.fuelTank);
        this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
        
        int validAcceleration = Math.Min(20, Math.Max(5, maxAcceleration));
        this.drivingProcessor = new DrivingProcessor(validAcceleration);
        this.drivingInformationDisplay = new DrivingInformationDisplay(this.drivingProcessor);
    }

    public bool EngineIsRunning => engine.IsRunning;

    public void BrakeBy(int speed)
    {
        if (EngineIsRunning)
        {
            drivingProcessor.ReduceSpeed(speed);
        }
    }

    public void Accelerate(int speed)
    {
        if (EngineIsRunning && fuelTank.FillLevel > 0)
        {
            if (speed > drivingProcessor.ActualSpeed)
            {
                drivingProcessor.IncreaseSpeedTo(speed);
                ConsumeFuelBasedOnSpeed();
            }
            else if (speed == drivingProcessor.ActualSpeed)
            {
                ConsumeFuelBasedOnSpeed();
            }
            else
            {
                FreeWheel();
            }
            
            if (fuelTank.FillLevel <= 0)
            {
                EngineStop();
            }
        }
    }

    public void EngineStart()
    {
        if (fuelTank.FillLevel > 0)
        {
            engine.Start();
        }
    }

    public void EngineStop()
    {
        engine.Stop();
    }

    public void FreeWheel()
    {
        if (drivingProcessor.ActualSpeed > 0)
        {
            drivingProcessor.ReduceSpeed(1);
        }
        else
        {
            RunningIdle();
        }
    }

    public void Refuel(double liters)
    {
        fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
        if (EngineIsRunning && fuelTank.FillLevel > 0)
        {
            engine.Consume(0.0003);
            
            if (fuelTank.FillLevel <= 0)
            {
                EngineStop();
            }
        }
    }
    
    private void ConsumeFuelBasedOnSpeed()
    {
        double consumption;
        int speed = drivingProcessor.ActualSpeed;
        
        if (speed <= 60)
        {
            consumption = 0.0020;
        }
        else if (speed <= 100)
        {
            consumption = 0.0014;
        }
        else if (speed <= 140)
        {
            consumption = 0.0020;
        }
        else if (speed <= 200)
        {
            consumption = 0.0025;
        }
        else
        {
            consumption = 0.0030;
        }
        
        engine.Consume(consumption);
    }
}

public class Engine : IEngine
{
    private IFuelTank fuelTank;

    public Engine()
    {
        IsRunning = false;
    }

    public Engine(IFuelTank fuelTank)
    {
        this.fuelTank = fuelTank;
        IsRunning = false;
    }

    public bool IsRunning { get; private set; }

    public void Consume(double liters)
    {
        if (IsRunning && fuelTank != null)
        {
            fuelTank.Consume(liters);
            if (fuelTank.FillLevel <= 0)
            {
                Stop();
            }
        }
    }

    public void Start()
    {
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }
}

public class FuelTank : IFuelTank
{
    private double fillLevel;
    private const double MaxFillLevel = 60.0;
    private const double ReserveLevel = 5.0;

    public FuelTank(double fillLevel)
    {
        this.fillLevel = Math.Max(0, Math.Min(fillLevel, MaxFillLevel));
    }

    public double FillLevel => Math.Round(fillLevel, 2);

    public bool IsOnReserve => fillLevel <= ReserveLevel;

    public bool IsComplete => fillLevel >= MaxFillLevel;

    public void Consume(double liters)
    {
        if (liters > 0)
        {
            fillLevel = Math.Max(0, fillLevel - liters);
        }
    }

    public void Refuel(double liters)
    {
        if (liters > 0)
        {
            fillLevel = Math.Min(MaxFillLevel, fillLevel + liters);
        }
    }
}

public class FuelTankDisplay : IFuelTankDisplay
{
    private readonly IFuelTank tank;

    public FuelTankDisplay(IFuelTank tank)
    {
        this.tank = tank;
    }

    public double FillLevel => tank.FillLevel;

    public bool IsOnReserve => tank.IsOnReserve;

    public bool IsComplete => tank.IsComplete;
}

public class DrivingInformationDisplay : IDrivingInformationDisplay
{
    private readonly IDrivingProcessor processor;
    
    public DrivingInformationDisplay(IDrivingProcessor processor)
    {
        this.processor = processor;
    }
    
    public int ActualSpeed => processor.ActualSpeed;
}

public class DrivingProcessor : IDrivingProcessor
{
    private int actualSpeed;
    private readonly int maxAcceleration;
    private const int MaxBraking = 10;
    private const int MaxSpeed = 250;
    
    public DrivingProcessor()
    {
        actualSpeed = 0;
        maxAcceleration = 10;
    }
    
    public DrivingProcessor(int maxAcceleration)
    {
        actualSpeed = 0;
        this.maxAcceleration = maxAcceleration;
    }
    
    public int ActualSpeed => actualSpeed;
    
    public void IncreaseSpeedTo(int targetSpeed)
    {
        if (targetSpeed <= actualSpeed)
        {
            return;
        }
        
        int possibleIncrease = Math.Min(maxAcceleration, targetSpeed - actualSpeed);
        actualSpeed = Math.Min(MaxSpeed, actualSpeed + possibleIncrease);
    }
    
    public void ReduceSpeed(int reduction)
    {
        int actualReduction = Math.Min(reduction, MaxBraking);
        
        actualSpeed = Math.Max(0, actualSpeed - actualReduction);
    }
}