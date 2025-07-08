using Raiding.Core.Interfaces;
using Raiding.Factory.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding.Core;
class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IHeroFactory factory;

    public Engine(IReader reader, IWriter writer, IHeroFactory factory)
    {
        this.reader = reader;
        this.writer = writer;
        this.factory = factory;
    }

    public void Run()
    {
        List<IHero> heroes = new();
        int count = int.Parse(reader.ReadLine());

        while (count > 0)
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            try
            {
                IHero hero = factory.Create(type, name);
                heroes.Add(hero);
                count--;
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        foreach (IHero hero in heroes)
        {
            writer.WriteLine(hero.CastAbility());
        }

        int bossPower = int.Parse(reader.ReadLine());
        int totalPower = heroes.Sum(h => h.Power);

        if (totalPower >= bossPower)
        {
            writer.WriteLine("Victory!");
        }
        else
        {
            writer.WriteLine("Defeat...");
        }
    }
}
