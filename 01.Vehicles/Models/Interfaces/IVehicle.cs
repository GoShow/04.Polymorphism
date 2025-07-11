﻿namespace Vehicles.Models.Interfaces;

public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumption { get; }
    double TankCapacity { get; }
    bool Drive(double distance);
    bool Refuel(double amount);
}
