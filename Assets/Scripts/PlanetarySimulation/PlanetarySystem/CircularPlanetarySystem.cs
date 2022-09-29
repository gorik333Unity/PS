using Helpers;
using PlanetarySimulation.Objects;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PlanetarySimulation.PlanetarySystem
{
    public class CircularPlanetarySystem : IPlanetarySystem
    {
        private readonly List<IPlanetaryObject> _planetaryObject = new List<IPlanetaryObject>();
        private readonly List<Planet> _planet = new List<Planet>();
        private readonly List<Circle> _circle = new List<Circle>();

        private readonly PlanetSystemContainer _container;
        private readonly Transform _center;

        public CircularPlanetarySystem(PlanetSystemContainer container, Planet[] planets)
        {
            InitializeSystem(planets);
            BuildSystem(planets, container);

            _center = container.Center;
            _container = container;
        }

        public IEnumerable<IPlanetaryObject> PlanetaryObject => _planetaryObject;

        public void Update(float deltaTime)
        {
            PlanetRotateAround(deltaTime);
            PlanetSelfRotate(deltaTime);
        }

        private void PlanetRotateAround(float deltaTime)
        {
            foreach (var item in _planet)
            {
                var planetTransform = item.PlanetModel.Model.transform;
                var movementAxis = item.PlanetaryObject.PlanetData.MovementAxis;
                var moveSpeed = item.PlanetaryObject.PlanetData.MoveSpeed;
                planetTransform.RotateAround(_center.position, movementAxis, deltaTime * moveSpeed);
            }
        }

        private void PlanetSelfRotate(float deltaTime)
        {
            foreach (var item in _planet)
            {
                var planetTransform = item.PlanetModel.Model.transform;
                var movementAxis = item.PlanetaryObject.PlanetData.MovementAxis;
                var moveSpeed = item.PlanetaryObject.PlanetData.MoveSpeed;
                planetTransform.RotateAround(_center.position, movementAxis, deltaTime * moveSpeed);
            }
        }

        private void BuildSystem(Planet[] planets, PlanetSystemContainer container)
        {
            var prefab = container.CirclePrefab;

            Planet previous = null;

            foreach (var item in planets)
            {
                var circle = Object.Instantiate(prefab, container.transform);
                SetCircleRadius(circle, item, previous);
                circle.ModelMeshRenderer.material = item.PlanetModel.MeshRenderer.material;
                item.transform.SetParent(circle.SpawnPoint);
                item.transform.localPosition = Vector3.zero;
                _circle.Add(circle);
            }
        }

        private void SetCircleRadius(Circle circle, Planet current, Planet previous)
        {
            circle.Model.localScale *= (float)current.Size * 2; // diameter
            if (previous == null)
            {
                return;
            }

            var a = current.PlanetModel.Model.transform.position;
            var b = previous.PlanetModel.Model.transform.position;
            var distance = Extensions.PerformanceDistance(a, b);
            var totalSize = (current.Size + previous.Size) * 2; // diameter

            if (totalSize > distance)
            {
                var normalized = distance / totalSize;
                circle.Model.localScale *= (float)normalized;
            }
        }

        private void InitializeSystem(Planet[] planets)
        {
            _planet.AddRange(planets);

            foreach (var item in planets)
            {
                if (item == null)
                {
                    throw new System.NullReferenceException(nameof(item));
                }

                _planetaryObject.Add(item.PlanetaryObject);
            }
        }
    }
}
