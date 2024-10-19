using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private Rotator _playerRotator;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private Carrier _playerCarrier;

    private void Awake()
    {
        PCPlayerInput playerInput = new PCPlayerInput();
        _playerMover.Init(playerInput);
        _playerRotator.Init(playerInput);
        _playerAnimationController.Init(playerInput, _playerCarrier);
        _playerCarrier.Init(playerInput);
    }
}
