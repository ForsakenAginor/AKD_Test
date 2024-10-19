using UnityEngine;

public interface IPlayerInput
{
    public Vector2 GetRotation();

    public Vector2 GetDirection();

    public bool IsInteractButtonPressed();
}

