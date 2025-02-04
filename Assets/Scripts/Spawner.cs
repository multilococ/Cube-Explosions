using UnityEngine;

[RequireComponent(typeof(Bomber))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;
    private int _maxSpawnChildrenChance = 100;

    public void SpawnChildrens(int spawnChildrenChance)
    {
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount + 1);

        Cube[] childrenCubes = new Cube[childrenCount];

        if (Random.Range(0, _maxSpawnChildrenChance + 1) <= spawnChildrenChance)
        {
            for (int i = 0; i < childrenCount; i++)
            {
                childrenCubes[i] = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
                childrenCubes[i].ReduceParameters();
                childrenCubes[i].GetComponent<Bomber>().ScatterObjects();
            }
        }

        Destroy(gameObject);
    }
}
