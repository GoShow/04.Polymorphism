namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double AirConditionerConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption
        => base.FuelConsumption + AirConditionerConsumption;

    public override bool Refuel(double amount)
        => base.Refuel(amount * 0.95);
}
