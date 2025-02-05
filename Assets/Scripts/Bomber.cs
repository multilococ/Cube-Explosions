using UnityEngine;

public class Bomber
{   
    public void Explode(Cube cube,float explosionRadius,float explosionForce)
    {
        Vector3 explodePoint = cube.transform.position;

        Collider[] overlappdeColliders = Physics.OverlapSphere(explodePoint, explosionRadius);

        Debug.Log("BOOM!");

        foreach (Collider collider in overlappdeColliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, explodePoint, explosionRadius);
                
            }
        }
    }
}
