using UnityEngine;

namespace PlanetarySimulation
{
    public class Circle : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private Transform _model;

        [SerializeField]
        private MeshRenderer _modelMeshRenderer;

        private void Awake()
        {
            if (_spawnPoint == null)
            {
                throw new System.NullReferenceException(nameof(_spawnPoint));
            }
            if (_model == null)
            {
                throw new System.NullReferenceException(nameof(_model));
            }
            if (_modelMeshRenderer == null)
            {
                throw new System.NullReferenceException(nameof(_modelMeshRenderer));
            }
        }

        public Transform Model => _model;
        public Transform SpawnPoint => _spawnPoint;
        public MeshRenderer ModelMeshRenderer => _modelMeshRenderer;
    }
}
