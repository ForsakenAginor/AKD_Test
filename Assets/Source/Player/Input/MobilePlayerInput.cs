using UnityEngine;
using UnityEngine.EventSystems;

public class MobilePlayerInput : IPlayerInput
{
    private NewInput _input;

    public MobilePlayerInput()
    {
        _input = new NewInput();
        _input.Enable();
    }

    public Vector2 GetDirection()
    {
        return _input.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetRotation()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return Vector2.zero;

        return _input.Player.Look.ReadValue<Vector2>();
    }

    public bool IsInteractButtonPressed()
    {
        return _input.Player.Fire.WasReleasedThisFrame();
    }
}


