using UnityEngine;

namespace PlanetarySimulation
{
    public class PlanetModel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _model;

        [SerializeField]
        private MeshRenderer _meshRenderer;

        public GameObject Model => _model;
        public MeshRenderer MeshRenderer => _meshRenderer;
    }
}
