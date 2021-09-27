using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsLimiter : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector2 _maxPosition;
    private Vector2 _minPosition;

    public Vector2[] Bounds { get; set; }

    public void CheckOutOfBounds()
    {
        Vector3 _newPosition = transform.position;

        if (transform.position.x > _maxPosition.x) _newPosition.x = _maxPosition.x - 0.01f;
        if (transform.position.y < _maxPosition.y) _newPosition.y = _maxPosition.y + 0.01f;
        if (transform.position.x < _minPosition.x) _newPosition.x = _minPosition.x + 0.01f;
        if (transform.position.y > _minPosition.y) _newPosition.y = _minPosition.y - 0.01f;

        transform.position = _newPosition;
    }

    public void CalculateCameraBounds()
    {
        _minPosition = new Vector2(Bounds[0].x + GetCameraWorldScale().x, Bounds[0].y - GetCameraWorldScale().y);
        _maxPosition = new Vector2(Bounds[1].x - GetCameraWorldScale().x, Bounds[1].y + GetCameraWorldScale().y);
    }

    public Vector2 GetCameraWorldScale() => _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight)) - _camera.transform.position;

    public bool CheckAvailabilityCameraSize(float _newSize)
    {
        float _oldSize = _camera.orthographicSize;
        _camera.orthographicSize = _newSize;

        bool _result = GetCameraWorldScale().y < (Bounds[0].y - Bounds[1].y) / 2;

        _camera.orthographicSize = _oldSize;

        return _result;
    }
}
