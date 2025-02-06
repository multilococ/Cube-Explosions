using UnityEngine;

public class Cube : MonoBehaviour
{
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

    public bool ReturnChance()
    {
        return Random.Range(0, _maxSpawnChildrenChance + 1) <= _spawnChildrenChance;
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
