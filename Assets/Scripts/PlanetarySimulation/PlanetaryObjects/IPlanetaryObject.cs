using Helpers;
using System.Numerics;

namespace PlanetarySimulation.Objects
{
    public interface IPlanetaryObject : IDeepCopyable<IPlanetaryObject>
    {
        string Name { get; }
        double Mass { get; }
        IPlanetObjectData PlanetData { get; }
    }
}
