using PlanetarySimulation.PlanetarySystem;

namespace PlanetarySimulation.Factories
{
    public interface IPlanetaryFactory
    {
        IPlanetarySystem Create(double mass);
    }
}
