using Codewars.ConstructingCar.Interfaces;
using System;

namespace Codewars.ConstructingCar;

public class Car : ICar
{
    public IFuelTankDisplay fuelTankDisplay;

    private IEngine engine;

    private IFuelTank fuelTank;

    public Car()
    {
        this.fuelTank = new FuelTank(20);
        this.engine = new Engine(this.fuelTank);
        this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
    }

    public Car(double fuelLevel)
    {
        this.fuelTank = new FuelTank(fuelLevel);
        this.engine = new Engine(this.fuelTank);
        this.fuelTankDisplay = new FuelTankDisplay(this.fuelTank);
    }

    public bool EngineIsRunning => engine.IsRunning;

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