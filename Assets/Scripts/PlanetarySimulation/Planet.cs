using PlanetarySimulation.Objects;
using UnityEngine;

namespace PlanetarySimulation
{
    public class Planet : MonoBehaviour
    {
        private PlanetModel _model;
        private IPlanetaryObject _planetaryObject;

        public PlanetModel PlanetModel => _model;
        public IPlanetaryObject PlanetaryObject => _planetaryObject;
        public double Size => _planetaryObject.PlanetData.Radius;

        public void SetModel(PlanetModel model)
        {
            if (model == null)
            {
                throw new System.ArgumentNullException(nameof(model));
            }

            _model = model;
        }

        public void SetPlanetObject(IPlanetaryObject planetaryObject)
        {
            if (planetaryObject == null)
            {
                throw new System.ArgumentNullException(nameof(planetaryObject));
            }

            gameObject.name = planetaryObject.Name;
            _planetaryObject = planetaryObject;
        }
    }
}
