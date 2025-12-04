using System.Collections.Generic;
using UnityEngine;

public class HandlerHit : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Raycast _raycast;

    private void OnEnable() =>
        _inputReader.PressedButton += _raycast.PressRaycast;

    private void OnDisable() =>
        _inputReader.PressedButton -= _raycast.PressRaycast;
}