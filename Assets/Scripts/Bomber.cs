using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomber : MonoBehaviour
{
    [SerializeField] private float _spawnScatterRadius = 20f;
    [SerializeField] private float _spawnScatterForce = 500f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ScatterObjects()
    {
        _rigidbody.AddExplosionForce(_spawnScatterForce, transform.position, _spawnScatterRadius);
    }
}
