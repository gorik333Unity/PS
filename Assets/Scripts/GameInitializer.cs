using PlanetarySimulation.Factories;
using PlanetarySimulation.PlanetarySystem;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField]
    private double _mass;

    [SerializeField]
    private float _simulationTimeScale;

    [SerializeReference, SubclassSelector]
    private IPlanetaryFactory _planetaryFactory;

    private IPlanetarySystem _planetarySystem;

    private void Awake()
    {
        InitializePlanetarySystem();
    }

    private void Update()
    {
        PlanetarySystemOnUpdate();
    }

    private void PlanetarySystemOnUpdate()
    {
        if (_planetarySystem == null)
        {
            throw new System.NullReferenceException(nameof(_planetarySystem));
        }

        var deltaTime = Time.deltaTime * _simulationTimeScale;
        _planetarySystem.Update(deltaTime);
    }

    private void InitializePlanetarySystem()
    {
        if (_planetaryFactory == null)
        {
            throw new System.NullReferenceException(nameof(_planetaryFactory));
        }

        _planetarySystem = _planetaryFactory.Create(_mass);
    }
}
