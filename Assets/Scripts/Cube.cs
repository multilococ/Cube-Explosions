using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action SpawnChildrenChanceIsWorked;
    public event Action ExplodeChanceIsWorked;

    [SerializeField] private float _explosionForce = 150;
    [SerializeField] private float _explosionRadius = 650;

    private Colorizer _colorizer = new Colorizer();

    private int _spawnChildrenChance = 100;
    private int _maxSpawnChildrenChance = 100;
    private int _spawnChanceloweringFactor = 2;
    private int _scaleloweringFactor = 2;

    private float _explosionScaleFacor = 1.5f;

    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    private void Awake()
    {
        _colorizer.SetRandomColor(transform.GetComponent<Renderer>());
    }

    public void DestroyObjectWithChance()
    {
        if (UnityEngine.Random.Range(0, _maxSpawnChildrenChance + 1) <= _spawnChildrenChance)
        {
            SpawnChildrenChanceIsWorked?.Invoke();
        }
        else
        {
            ExplodeChanceIsWorked?.Invoke();
        }

        Destroy(gameObject);
    }

    public void ReduceParameters()
    {
        Vector3 scale = transform.localScale;

        _spawnChildrenChance /= _spawnChanceloweringFactor;
        scale /= _scaleloweringFactor;
        transform.localScale = scale;
        _explosionRadius *= _explosionScaleFacor;
        _explosionForce *= _explosionScaleFacor;
    }
}
