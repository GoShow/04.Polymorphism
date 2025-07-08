using System;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory vehicleFactory;
    public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.vehicleFactory = vehicleFactory;
    }

    public void Run()
    {
        string[] carTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] truckTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] busTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IVehicle car = vehicleFactory.Create("Car", double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
        IVehicle truck = vehicleFactory.Create("Truck", double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));
        IVehicle bus = vehicleFactory.Create("Bus", double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandTokens[0];
                string vehicleType = commandTokens[1];

                IVehicle vehicleToProcess = default;

                switch (vehicleType)
                {
                    case "Car":
                        vehicleToProcess = car;
                        break;
                    case "Truck":
                        vehicleToProcess = truck;
                        break;
                    case "Bus":
                        vehicleToProcess = bus;
                        break;
                }

                switch (command)
                {
                    case "Drive":
                        Drive(vehicleToProcess, double.Parse(commandTokens[2]));
                        break;
                    case "Refuel":
                        Refuel(vehicleToProcess, double.Parse(commandTokens[2]));
                        break;
                    case "DriveEmpty":
                        DriveEmpty((ISpecializedVehicle)vehicleToProcess, double.Parse(commandTokens[2]));
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        writer.WriteLine(car.ToString());
        writer.WriteLine(truck.ToString());
        writer.WriteLine(bus.ToString());
    }

    private void Drive(IVehicle vehicle, double distance)
    {
        bool isDriven = vehicle.Drive(distance);

        if (isDriven)
        {
            writer.WriteLine($"{vehicle.GetType().Name} travelled {distance} km");
        }
        else
        {
            writer.WriteLine($"{vehicle.GetType().Name} needs refueling");
        }
    }

    private void Refuel(IVehicle vehicle, double amount)
    {
        bool isRefueled = vehicle.Refuel(amount);

        if (!isRefueled)
        {
            writer.WriteLine($"Cannot fit {amount} fuel in the tank");
        }
    }

    private void DriveEmpty(ISpecializedVehicle vehicle, double distance)
    {
        bool isDriven = vehicle.DriveEmpty(distance);

        if (isDriven)
        {
            writer.WriteLine($"{vehicle.GetType().Name} travelled {distance} km");
        }
        else
        {
            writer.WriteLine($"{vehicle.GetType().Name} needs refueling");
        }
    }
}
