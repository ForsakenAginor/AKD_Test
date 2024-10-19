using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _strafeSpeed = 1.0f;
    [SerializeField] private Camera _camera;

    private CharacterController _characterController;
    private IPlayerInput _input;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (_input == null)
            return;

        Vector2 axis = _input.GetDirection();
        Move(axis);
    }

    public void Init(IPlayerInput input)
    {
        _input = input != null ? input : throw new ArgumentNullException(nameof(input));
    }

    private void Move(Vector2 axis)
    {
        Vector3 forward = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(_camera.transform.right, Vector3.up).normalized;
        Vector3 direction;

        if (_characterController != null)
        {
            if (_characterController.isGrounded)
            {
                direction = _speed * axis.y * forward + _strafeSpeed * axis.x * right;

                if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))
                    direction = Vector3.ProjectOnPlane(direction, hitInfo.normal).normalized * direction.magnitude;

                _characterController.Move(direction * Time.deltaTime);
            }
        }
    }
}
