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
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount);

        if (Random.Range(0, _maxSpawnChildrenChance) <= _spawnChildrenChance)
        {
            for (int i = 0; i <= childrenCount; i++)
            {
                GameObject children = Instantiate(_children, transform.position, Quaternion.identity);

                children.GetComponent<ExplodingCube>().ReduceParameters();
            }
        }

        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] overlappdeColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in overlappdeColliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }

    private void SetRandomColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        gameObject.GetComponent<Renderer>().material.color = randomColor;
    }
}
