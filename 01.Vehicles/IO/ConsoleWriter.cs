using System;
using Vehicles.IO.Interfaces;

namespace Vehicles.IO;
public class ConsoleWriter : IWriter
{
    public void WriteLine(string line) => Console.WriteLine(line);
}

