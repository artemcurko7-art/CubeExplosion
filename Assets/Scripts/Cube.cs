using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public void Spawner()
    {
        List<GameObject> cubes = new List<GameObject>();

        int minRange = 2;
        int maxRange = 6;

        int amountCubes = Random.Range(minRange, maxRange + 1);

        for (int i = 0; i < amountCubes; i++)
        {
            GameObject cube = Instantiate(gameObject, transform.position, Quaternion.identity);
            cubes.Add(cube);
            cube.transform.localScale = GetScale(cube.transform.localScale);
            cube.GetComponent<MeshRenderer>().material.color = GetColor();
        }

        //Destroy(gameObject);
    }

    private Vector3 GetScale(Vector3 scale)
    {
        int numberReduction = 2;

        scale.x /= numberReduction;
        scale.y /= numberReduction;
        scale.z /= numberReduction;

        return scale;
    }
    
    private Color GetColor()
    {
        Color color = Random.ColorHSV();

        return color;
    }
}
