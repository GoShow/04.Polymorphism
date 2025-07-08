using Vehicles.Models.Interfaces;

namespace Vehicles.Models;
public class Bus : Vehicle, ISpecializedVehicle
{
    private const double AirConditionerConsumption = 1.4;
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption
        => base.FuelConsumption + AirConditionerConsumption;

    public bool DriveEmpty(double distance)
    {
        base.FuelConsumption -= AirConditionerConsumption;

        return Drive(distance);
    }
}
