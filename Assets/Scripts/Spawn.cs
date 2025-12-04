using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private HandlerHit _handlerHit;
    [SerializeField] private GameObject _prefab;

    public List<GameObject> GetObjectsSpawn()
    {
        List<GameObject> cubes = new List<GameObject>();
        Vector3 origin = _handlerHit.GetPositionHit().position;

        int minRange = 2;
        int maxRange = 6;

        int percent = 100;
        int numberReduce = 2;
        int changedPercent = percent;

        int amountCubes = Random.Range(minRange, maxRange + 1);

        for (int i = 0; i < amountCubes; i++)
        {
            int currentPercent = Random.Range(0, percent + 1);

            if (currentPercent <= changedPercent)
            {
                GameObject cube = Instantiate(_prefab, origin, Quaternion.identity);
                cubes.Add(cube);
            }
            else
            {
                Destroy(_handlerHit.GetPositionHit().gameObject);
                break;
            }

            changedPercent /= numberReduce;
        }

        return cubes;
    }
}
