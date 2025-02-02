using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplodingCube : MonoBehaviour
{
    [SerializeField] private GameObject _children;

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;
    private int _spawnChildrenChance = 100;

    private Color _color;

    private void Start()
    {
        _color = new Color(0.2f, 0.60f, 0.9f) ;
        gameObject.GetComponent<Renderer>().material.color = _color;
    }

    public void ReduceParameters()
    {
        _spawnChildrenChance /= 2;
        Vector3 scale = transform.localScale;
        scale /= 2;
        transform.localScale = scale;
    }

    private void OnMouseDown()
    {
        for (int i = _minChildrenCount; i <= _maxChildrenCount; i++)
        {
            GameObject children = Instantiate(_children, transform.position, Quaternion.identity);
            children.GetComponent<ExplodingCube>().ReduceParameters();
        }

        Destroy(gameObject);
    }
}
