using UnityEngine;

namespace PlanetarySimulation
{
    public class PlanetSystemContainer : MonoBehaviour
    {
        [SerializeField]
        private Transform _center;

        [SerializeField]
        private Circle _circlePrefab;

        public Transform Center => _center;
        public Circle CirclePrefab => _circlePrefab;
    }
}
