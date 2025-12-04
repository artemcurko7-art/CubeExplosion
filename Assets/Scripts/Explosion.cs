using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _minRangeExplodeForce;
    [SerializeField] private int _maxRangeExplodeForce;
    [SerializeField] private int _minRangeExplodeRadius;
    [SerializeField] private int _maxRangeExplodeRadius;

    public void Explode(List<Cube> cubes, Vector3 origin)
    {
        foreach (var cube in GetExplodableObjects(cubes))
            cube.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(_minRangeExplodeForce, _maxRangeExplodeForce), origin, Random.Range(_minRangeExplodeRadius, _maxRangeExplodeRadius));
    }

    private List<Cube> GetExplodableObjects(List<Cube> cubes)
    {
        foreach (var cube in cubes)
            if (cube.GetComponent<Collider>().attachedRigidbody != null)
                cubes.Add(cube);

        return cubes;
    }
}
