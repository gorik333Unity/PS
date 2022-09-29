using PlanetarySimulation.Objects;
using System.Collections.Generic;

namespace PlanetarySimulation.PlanetarySystem
{
    public interface IPlanetarySystem
    {
        IEnumerable<IPlanetaryObject> PlanetaryObject { get; }
        void Update(float deltaTime);
    }
}
