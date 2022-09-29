using Helpers;
using PlanetarySimulation.Objects;
using PlanetarySimulation.PlanetarySystem;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PlanetarySimulation.Factories
{
    [System.Serializable]
    public class StandartPlanetaryFactory : IPlanetaryFactory
    {
        [SerializeField]
        private PlanetSystemContainer _containerPrefab;

        [SerializeField]
        private Planet _planetPrefab;

        [SerializeField, Range(1, 2)]
        private int _minPlanetCount;

        [SerializeReference, SubclassSelector]
        private IPlanetaryObject[] _available;

        public IPlanetarySystem Create(double mass)
        {
            var container = CreateContainer(_containerPrefab);
            var planets = CreatePlanets(container, mass);
            var system = new CircularPlanetarySystem(container, planets);

            return system;
        }

        private PlanetSystemContainer CreateContainer(PlanetSystemContainer container)
        {
            if (container == null)
            {
                throw new System.ArgumentNullException(nameof(container));
            }

            return Object.Instantiate(container);
        }

        private Planet[] CreatePlanets(PlanetSystemContainer container, double mass)
        {
            double currentMass = 0d;
            var planets = new List<Planet>();
            int planetCount = 0;

            while (mass > currentMass)
            {
                var randomPlanet = _available.Random();
                var copy = randomPlanet.DeepCopy();
                var data = copy.PlanetData;
                if (currentMass + data.Mass > mass && planetCount <= _minPlanetCount)
                {
                    continue;
                }
                data.RandomPlanetData();
                var planet = Object.Instantiate(_planetPrefab, container.transform);
                var planetObject = Object.Instantiate(data.Model, planet.transform);
                InitializePlanet(copy, planet, planetObject);
                planets.Add(planet);

                planetCount++;
                currentMass += data.Mass;
            }

            return planets.ToArray();
        }

        private void InitializePlanet(IPlanetaryObject planetary, Planet planet, PlanetModel planetModel)
        {
            var radius = (float)planetary.PlanetData.Radius * 2; // diameter
            var scale = new Vector3(radius, radius, radius);
            planetModel.transform.localScale = scale;
            planet.SetModel(planetModel);
            planet.SetPlanetObject(planetary);
        }
    }
}
