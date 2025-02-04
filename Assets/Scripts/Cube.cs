using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    
    private int _spawnChildrenChance = 100;
    private int _spawnChanceloweringFactor = 2;
    private int _scaleloweringFactor = 2;

    private void OnMouseDown()
    {
        _spawner.SpawnChildrens(_spawnChildrenChance);
    }
  
    public void ReduceParameters()
    {
        Vector3 scale = transform.localScale;

        _spawnChildrenChance /= _spawnChanceloweringFactor;
        scale /= _scaleloweringFactor;
        transform.localScale = scale;
    }
}
