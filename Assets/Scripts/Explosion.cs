using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _minRangeExplodeForce;
    [SerializeField] private int _maxRangeExplodeForce;
    [SerializeField] private int _minRangeExplodeRadius;
    [SerializeField] private int _maxRangeExplodeRadius;

    public void Explode(Vector3 origin)
    {
        foreach (var cube in GetExplodableObjects(origin))
            cube.AddExplosionForce(Random.Range(_minRangeExplodeForce, _maxRangeExplodeForce), origin, Random.Range(_minRangeExplodeRadius, _maxRangeExplodeRadius));
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 origin)
    {
        List<Rigidbody> cubes = new List<Rigidbody>();

        Collider[] hits = Physics.OverlapSphere(origin, Random.Range(_minRangeExplodeRadius, _maxRangeExplodeRadius));

        foreach (var hit in hits)
            if (hit.attachedRigidbody != null && hit.gameObject != gameObject)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
