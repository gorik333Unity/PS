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
                var planetTransform = item.transform;
                var movementAxis = item.PlanetaryObject.PlanetData.MovementAxis;
                var moveSpeed = item.PlanetaryObject.PlanetData.MoveSpeed;
                planetTransform.RotateAround(_center.position, movementAxis, deltaTime * moveSpeed);
            }
        }

        private void PlanetSelfRotate(float deltaTime)
        {
            foreach (var item in _planet)
            {
                var planetModelTransform = item.PlanetModel.Model.transform;
                var rotationDirection = item.PlanetaryObject.PlanetData.SelfRotationDirection;
                var rotateSpeed = item.PlanetaryObject.PlanetData.RotateSpeed;
                planetModelTransform.Rotate(rotationDirection, deltaTime * rotateSpeed);
            }
        }

        private void BuildSystem(Planet[] planets, PlanetSystemContainer container)
        {
            var prefab = container.CirclePrefab;
            foreach (var item in planets)
            {
                var circle = Object.Instantiate(prefab, container.transform);
                circle.ModelMeshRenderer.material = item.PlanetModel.MeshRenderer.material;
                SetCircleRadius(circle, item);
                item.transform.SetParent(circle.SpawnPoint);
                item.transform.localPosition = Vector3.zero;
                _circle.Add(circle);
            }
        }

        private void SetCircleRadius(Circle circle, Planet current)
        {
            circle.Model.localScale *= (float)current.Size * 2; // diameter
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
