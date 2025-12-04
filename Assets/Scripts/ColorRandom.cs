using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorRandom : MonoBehaviour
{
    public void ApplyColor(List<Cube> cubes)
    {
        foreach (var cube in cubes)
            if (cube.TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
                meshRenderer.material.color = Random.ColorHSV();
    }
}
