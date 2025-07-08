using Raiding.Models.Interfaces;

namespace Raiding.Factory.Interfaces;
public interface IHeroFactory
{
    IHero Create(string type, string name);
}
