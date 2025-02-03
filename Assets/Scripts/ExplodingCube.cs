using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplodingCube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 500f;

    private GameObject _children;

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;
    private int _maxSpawnChildrenChance = 100;
    private int _spawnChildrenChance = 100;
    private int _loweringFactor = 2;

    public void ReduceParameters()
    {
        Vector3 scale = transform.localScale;

        _spawnChildrenChance /= _loweringFactor;
        scale /= _loweringFactor;
        transform.localScale = scale;
    }

    private void Start()
    {
        SetRandomColor();
        _children = gameObject;
    }

    private void OnMouseDown()
    {
        SpawnChildrens();
    }

    private void SpawnChildrens()
    {
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount + 1);

        GameObject[] childrens = new GameObject[childrenCount];

        if (Random.Range(0, _maxSpawnChildrenChance + 1) <= _spawnChildrenChance)
        {
            for (int i = 0; i < childrenCount; i++)
            {
                childrens[i] = Instantiate(_children, transform.position, Quaternion.identity);
                childrens[i].GetComponent<ExplodingCube>().ReduceParameters();
                childrens[i].GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

            }
        }

        Destroy(gameObject);
    }

    private void SetRandomColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        gameObject.GetComponent<Renderer>().material.color = randomColor;
    }
}
