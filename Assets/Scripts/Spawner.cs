using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Cube _cube;

    private Spreader _spreader = new Spreader();

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;

    public void SetCube(Cube cube)
    {
        if (_cube != null)
        {
            _cube = cube;
            _cube.SpawnChildrenChanceIsWorked += SpawnChildrens;
        }
    }

    private void SpawnChildrens()
    {
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount + 1);

        Cube[] childrenCubes = new Cube[childrenCount];

        for (int i = 0; i < childrenCount; i++)
        {
            childrenCubes[i] = Instantiate(_cube, _cube.transform.position, Quaternion.identity);
            childrenCubes[i].ReduceParameters();
            _spreader.ScatterObject(childrenCubes[i]);
        }

        _cube.SpawnChildrenChanceIsWorked -= SpawnChildrens;
    }
}
