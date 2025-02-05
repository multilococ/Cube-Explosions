using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Spreader _spreader = new Spreader();

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;

    private void OnEnable()
    {
        _cubePrefab.SpawnChildrens += SpawnChildrens;
    }

    private void OnDisable()
    {
        _cubePrefab.SpawnChildrens -= SpawnChildrens;
    }

    private void SpawnChildrens()
    {
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount + 1);

        Cube[] childrenCubes = new Cube[childrenCount];

        for (int i = 0; i < childrenCount; i++)
        {
            childrenCubes[i] = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            childrenCubes[i].ReduceParameters();
            _spreader.ScatterObject(childrenCubes[i]);
        }

        Destroy(gameObject);
    }
}
