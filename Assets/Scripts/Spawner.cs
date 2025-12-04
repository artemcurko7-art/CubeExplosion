using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CalculatingChanceSeparation _calculation;
    [SerializeField] private Raycast _raycast;
    [SerializeField] private Cube _cube;

    public List<Cube> GetObjectsSpawn()
    {
        List<Cube> cubes = new List<Cube>();
        Transform origin = _raycast.GetTransformHit();

        for (int i = 0; i < _calculation.GetAmount(); i++)
        {
            Debug.Log($"Count cubes: {_calculation.GetAmount()}");
            Cube cube = Instantiate(_cube.gameObject, origin.position, Quaternion.identity).GetComponent<Cube>();
            cubes.Add(cube);
        }

        Destroy(origin.gameObject);

        return cubes;
    }
}
