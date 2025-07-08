using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factory;
using Raiding.Factory.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace _03.Raiding;

internal class StartUp
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IHeroFactory factory = new HeroFactory();

        IEngine engine = new Engine(reader, writer, factory);

        engine.Run();
    }
}
