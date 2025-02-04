using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Cube : MonoBehaviour
{
    private Colorizer _colorizer = new Colorizer();

    private int _spawnChildrenChance = 100;
    private int _spawnChanceloweringFactor = 2;
    private int _scaleloweringFactor = 2;

    public int SpawnChildrenChance => _spawnChildrenChance;

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
    }
}
