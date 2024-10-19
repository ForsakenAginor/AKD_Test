using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    const string IsWalking = nameof(IsWalking);
    const string IsCarrying = nameof(IsCarrying);

    [SerializeField] private Animator _animator;

    private IPlayerInput _input;
    private Carrier _carrier;

    private void Update()
    {
        if (_input == null)
            return;

        if (_animator.GetBool(IsWalking) == false  && _input.GetDirection().y != 0)
            _animator.SetBool(IsWalking, true);
        else if (_animator.GetBool(IsWalking) == true && _input.GetDirection().y == 0)
            _animator.SetBool(IsWalking, false);
    }

    private void OnDestroy()
    {
        _carrier.CarryingStarted -= OnCarryingStarted;
        _carrier.CarryingAborted -= OnCarryingAborted;
    }

    public void Init(IPlayerInput input, Carrier carrier)
    {
        _input = input != null ? input : throw new ArgumentNullException(nameof(input));
        _carrier = carrier != null ? carrier : throw new ArgumentNullException(nameof(carrier));

        _carrier.CarryingStarted += OnCarryingStarted;
        _carrier.CarryingAborted += OnCarryingAborted;
    }

    private void OnCarryingAborted()
    {
        _animator.SetBool(IsCarrying, false);
    }

    private void OnCarryingStarted()
    {
        _animator.SetBool(IsCarrying, true);
    }
}
