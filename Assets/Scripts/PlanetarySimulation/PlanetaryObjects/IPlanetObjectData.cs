using Helpers;
using UnityEngine;

namespace PlanetarySimulation.Objects
{
    public interface IPlanetObjectData : IDeepCopyable<IPlanetObjectData>
    {
        PlanetModel Model { get; }
        double Mass { get; }
        double Radius { get; }
        float MoveSpeed { get; }
        float RotateSpeed { get; }
        Vector3 MovementAxis { get; }
        Vector3 SelfRotationDirection { get; }
        void RandomPlanetData();
    }
}
