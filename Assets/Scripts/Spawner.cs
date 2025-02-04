using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Bomber _bomber = new Bomber();

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;
    private int _maxSpawnChildrenChance = 100;

    private void OnMouseDown()
    {
        SpawnChildrens(_cubePrefab.SpawnChildrenChance);
    }

    private void SpawnChildrens(int spawnChildrenChance)
    {
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount + 1);

        Cube[] childrenCubes = new Cube[childrenCount];

        if (Random.Range(0, _maxSpawnChildrenChance + 1) <= spawnChildrenChance)
        {
            for (int i = 0; i < childrenCount; i++)
            {
                childrenCubes[i] = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
                childrenCubes[i].ReduceParameters();
                _bomber.ScatterObject(childrenCubes[i]);
            }
        }

        Destroy(gameObject);
    }
}
