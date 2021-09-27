using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [SerializeField] private float _minSize;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private CameraBoundsLimiter _cameraBoundsLimiter;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if(Input.mouseScrollDelta != Vector2.zero) ChangeCameraSize(-Input.mouseScrollDelta.y);
    }

    private void ChangeCameraSize(float _value)
    {
        float _newSize = _camera.orthographicSize + _value * _zoomSpeed;
        if (_newSize < _minSize || !_cameraBoundsLimiter.CheckAvailabilityCameraSize(_newSize)) return;
        _camera.orthographicSize = _newSize;

        _cameraBoundsLimiter.CalculateCameraBounds();
        _cameraBoundsLimiter.CheckOutOfBounds();
    }
}
