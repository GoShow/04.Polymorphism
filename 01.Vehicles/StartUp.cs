﻿using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

namespace _01.Vehicles;

internal class StartUp
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IVehicleFactory vehicleFactory = new VehicleFactory();

        IEngine engine = new Engine(reader, writer, vehicleFactory);

        engine.Run();
    }
}