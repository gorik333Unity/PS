using UnityEngine;

namespace PlanetarySimulation.Objects
{
    [System.Serializable]
    public class MassClass : IPlanetObjectData
    {
        [SerializeField]
        private PlanetModel _model;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _rotateSpeed;

        [SerializeField]
        private Vector3 _movementAxis;

        [SerializeField]
        private Vector3 _selfRotationDirection;

        [SerializeField]
        private double _minMass;

        [SerializeField]
        private double _maxMass;

        [SerializeField]
        private double _minRadius;

        [SerializeField]
        private double _maxRadius;

        private double _radius;
        private double _mass;

        public MassClass()
        {
            RandomPlanetData();
        }

        public MassClass(PlanetModel model, float moveSpeed, float rotateSpeed, Vector3 movementAxis, Vector3 selfRotationDirection, double minMass, double maxMass, double minRadius, double maxRadius)
        {
            _model = model;
            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;
            _movementAxis = movementAxis;
            _selfRotationDirection = selfRotationDirection;
            _minMass = minMass;
            _maxMass = maxMass;
            _minRadius = minRadius;
            _maxRadius = maxRadius;
        }

        public PlanetModel Model => _model;
        public double Mass => _mass;
        public double Radius => _radius;
        public Vector3 SelfRotationDirection => _selfRotationDirection;
        public Vector3 MovementAxis => _movementAxis;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;

        public IPlanetObjectData DeepCopy()
        {
            return new MassClass(_model, _moveSpeed, _rotateSpeed, _movementAxis, _selfRotationDirection, _minMass, _maxMass, _minRadius, _maxRadius);
        }

        public void RandomPlanetData()
        {
            _mass = GetRandomNumber(_minMass, _maxMass);
            _radius = GetRandomNumber(_minRadius, _maxRadius);
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            var random = new System.Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
