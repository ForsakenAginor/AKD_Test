using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterGravity : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _verticalVelocity = Vector3.zero;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (_characterController.isGrounded == false)
            _verticalVelocity += Physics.gravity * Time.deltaTime;

        Vector3 horizontalVelocity = _characterController.velocity;
        horizontalVelocity.y = 0;
        _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
    }
}
