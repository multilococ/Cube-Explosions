using System;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Cube : MonoBehaviour
{
    public event Action OnClick;

    [SerializeField] private float _eplosionForce = 150;
    [SerializeField] private float _explosionRadius = 650;

    private Colorizer _colorizer = new Colorizer();

    private Bomber _bomber = new Bomber();

    private int _spawnChildrenChance = 100;
    private int _maxSpawnChildrenChance = 100;
    private int _spawnChanceloweringFactor = 2;
    private int _scaleloweringFactor = 2;

    private float _explosionScaleFacor = 1.5f;

    private void OnMouseDown()
    {
        if (UnityEngine.Random.Range(0, _maxSpawnChildrenChance + 1) <= _spawnChildrenChance)
        {
            OnClick?.Invoke();
        }
        else
        {
            _bomber.Explode(this, _explosionRadius, _eplosionForce); ;
        }

        Destroy(gameObject);
    }

    private void Awake()
    {
        _colorizer.SetRandomColor(transform.GetComponent<Renderer>());
    }

    public void ReduceParameters()
    {
        Vector3 scale = transform.localScale;

        _spawnChildrenChance /= _spawnChanceloweringFactor;
        scale /= _scaleloweringFactor;
        transform.localScale = scale;
        _explosionRadius *= _explosionScaleFacor;
        _eplosionForce *= _explosionScaleFacor;
    }
}
