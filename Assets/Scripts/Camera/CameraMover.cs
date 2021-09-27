using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraBoundsLimiter _cameraBoundsLimiter;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0)) _startPosition = transform.position + _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            _targetPosition = _startPosition - _camera.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _moveSpeed);
        _cameraBoundsLimiter.CheckOutOfBounds();
    }
}
