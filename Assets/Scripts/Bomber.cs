using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Bomber : MonoBehaviour
{
    [SerializeField] private float _spawnScatterRadius = 20f;
    [SerializeField] private float _spawnScatterForce = 500f;
    
    [SerializeField] private Rigidbody _rigidbody;

    public void ScatterObjects() 
    {
        _rigidbody.AddExplosionForce(_spawnScatterForce, transform.position, _spawnScatterRadius);
    }
}
