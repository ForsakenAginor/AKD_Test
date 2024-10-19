using UnityEngine;

public class PCPlayerInput : IPlayerInput
{
    private const string AxisMouseX = "Mouse X";
    private const string AxisMouseY = "Mouse Y";
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public Vector2 GetDirection() => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

    public Vector2 GetRotation() => new Vector2(Input.GetAxis(AxisMouseX), Input.GetAxis(AxisMouseY));

    public bool IsInteractButtonPressed() => Input.GetKeyDown(KeyCode.Space);
}

