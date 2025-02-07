using UnityEngine;

public class Spreader
{
    private float _spawnScatterRadius = 20f;
    private float _spawnScatterForce = 500f;

    public void ScatterObject(Rigidbody cube)
    {
        Rigidbody rigidbody = cube;

        Vector3 scatteringPosition = cube.transform.position;

        rigidbody.AddExplosionForce(_spawnScatterForce, scatteringPosition, _spawnScatterRadius);
    }
}