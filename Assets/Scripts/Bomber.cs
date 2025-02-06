using UnityEngine;

public class Bomber : MonoBehaviour
{
    private Cube _cube;

    public void SetCube(Cube cube) 
    {
        if (_cube != null)
        {
            _cube = cube;
            _cube.ExplodeChanceIsWorked += Explode;
        }
    }

    private void Explode()
    {
        Vector3 explodePoint = _cube.transform.position;

        Collider[] overlappdeColliders = Physics.OverlapSphere(explodePoint,_cube.ExplosionRadius);

        Debug.Log("BOOM!");

        foreach (Collider collider in overlappdeColliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_cube.ExplosionForce, explodePoint, _cube.ExplosionRadius);
                
            }
        }

        _cube.ExplodeChanceIsWorked -= Explode;
    }
}
