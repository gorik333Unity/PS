using UnityEngine;

namespace PlanetarySimulation.Objects
{
    [System.Serializable]
    public class MainPlanetaryObject : IPlanetaryObject
    {
        [SerializeField]
        private string _name;

        [SerializeReference, SubclassSelector]
        private IPlanetObjectData _planetData;

        public MainPlanetaryObject()
        {
        }

        public MainPlanetaryObject(string name, IPlanetObjectData planetData)
        {
            _name = name;
            _planetData = planetData;
        }

        public IPlanetaryObject DeepCopy()
        {
            return new MainPlanetaryObject(_name, _planetData.DeepCopy());
        }

        public string Name => _name;
        public double Mass => _planetData.Mass;
        public IPlanetObjectData PlanetData => _planetData;
    }
}
