using System.Collections.Generic;
using UnityEngine;

public class HandlerHit : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spawn _spawn;
    [SerializeField] private Scale _scale;
    [SerializeField] private ColorRandom _colorRandom;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    public Transform GetPositionHit()
    {
        Transform transform = _hit.transform;

        return transform;
    }

    private void OnEnable() =>
        _inputReader.PressedButton += OnButtonClick;

    private void OnDisable() =>
        _inputReader.PressedButton -= OnButtonClick;

    private void OnButtonClick() =>
        PressRaycast();

    private void PressRaycast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
        {
            if (_hit.transform.TryGetComponent(out Cube cube))
            {
                List<GameObject> cubes = _spawn.GetObjectsSpawn();
                _scale.DecreaseScale(cubes);
                _colorRandom.ApplyColor(cubes);
                _explosion.Explode(GetPositionHit().position);
            }
        }
    }
}