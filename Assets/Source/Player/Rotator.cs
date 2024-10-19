using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalMouseSensitivity = 5;
    [SerializeField] private float _verticalMouseSensitivity = 10;

    private float _maxVerticalCameraAngle = 89;
    private float _minVerticalCameraAngle = -89;
    private float _currentVerticalCameraAngle = 0;
    private IPlayerInput _input;

    private void Awake()
    {
        _currentVerticalCameraAngle = _cameraTransform.rotation.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        if (_input == null)
            return;

        Vector2 rotation = _input.GetRotation();
        _currentVerticalCameraAngle -= rotation.y * _verticalMouseSensitivity;
        _currentVerticalCameraAngle = Mathf.Clamp(_currentVerticalCameraAngle, _minVerticalCameraAngle, _maxVerticalCameraAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _currentVerticalCameraAngle;
        transform.Rotate(rotation.x * _horizontalMouseSensitivity * Vector3.up);
    }

    public void Init(IPlayerInput input)
    {
        _input = input != null ? input : throw new ArgumentNullException(nameof(input));
    }
}

