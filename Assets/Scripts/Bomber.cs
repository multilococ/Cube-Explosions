using UnityEngine;

public class Bomber
{
    private float _spawnScatterRadius = 20f;
    private float _spawnScatterForce = 500f;

    public void ScatterObject(Cube cube)
    {
        Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

        Vector3 scatteringPosition = cube.transform.position;

        rigidbody.AddExplosionForce(_spawnScatterForce, scatteringPosition, _spawnScatterRadius);
    }
}
