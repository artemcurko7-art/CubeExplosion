using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Raycast : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spawner _spawn;
    [SerializeField] private Transformation _transformation;
    [SerializeField] private ColorRandom _colorRandom;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Camera _camera;

    private RaycastHit _hit;

    public void PressRaycast(Vector3 inputPosition)
    {
        Ray ray = _camera.ScreenPointToRay(inputPosition);

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            if (_hit.transform.TryGetComponent(out Cube cube))
            {
                List<Cube> cubes = _spawn.GetObjectsSpawn();
                _transformation.DecreaseScale(cubes);
                _colorRandom.ApplyColor(cubes);
                _explosion.Explode(cubes, inputPosition);
            }
        }
    }

    public Transform GetTransformHit() =>
        _hit.transform;
}
