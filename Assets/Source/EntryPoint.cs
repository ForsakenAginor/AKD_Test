using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<PickapableBox> _boxes;
    [SerializeField] private Carrier _player;
    [SerializeField] private float _pickupDistance = 2;
    [SerializeField] private OnScreenButton _throwButton;

    private void Start()
    {
        foreach (var box in _boxes)        
            box.Init(_player, _pickupDistance);

        _player.CarryingStarted += OnStartCarrying;
        _player.CarryingAborted += OnStopCarrying;
    }

    private void OnDestroy()
    {
        _player.CarryingStarted -= OnStartCarrying;
        _player.CarryingAborted -= OnStopCarrying;
    }

    private void OnStopCarrying()
    {
        _throwButton.gameObject.SetActive(false);
    }

    private void OnStartCarrying()
    {
        _throwButton.gameObject.SetActive(true);
    }
}
