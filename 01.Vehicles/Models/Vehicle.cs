using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get => fuelQuantity;
        private set
        {
            if (TankCapacity < value)
            {
                fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    }
    public virtual double FuelConsumption { get; protected set; }
    public double TankCapacity { get; private set; }

    public bool Drive(double distance)
    {
        if (FuelQuantity < distance * FuelConsumption)
        {
            return false;
        }

        FuelQuantity -= distance * FuelConsumption;

        return true;
    }

    public virtual bool Refuel(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (FuelQuantity + amount > TankCapacity)
        {
            return false;
        }

        FuelQuantity += amount;

        return true;
    }

    public override string ToString()
        => $"{GetType().Name}: {FuelQuantity:f2}";
}
