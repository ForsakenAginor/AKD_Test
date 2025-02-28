using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private Rotator _playerRotator;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private Carrier _playerCarrier;

    private void Awake()
    {
        IPlayerInput playerInput = new MobilePlayerInput();
        _playerMover.Init(playerInput);
        _playerRotator.Init(playerInput);
        _playerAnimationController.Init(playerInput, _playerCarrier);
        _playerCarrier.Init(playerInput);
    }
}
