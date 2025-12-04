using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    public void DecreaseScale(List<Cube> cubes)
    {
        foreach (var cube in cubes)
            cube.transform.localScale = GetScale();
    }

    public Vector3 GetScale()
    {
        var scale = transform.localScale;

        int numberReduction = 2;

        scale.x /= numberReduction;
        scale.y /= numberReduction;
        scale.z /= numberReduction;

        return scale;
    }
}
