using System;
using UnityEngine;

public class Carrier : MonoBehaviour
{
    [SerializeField] private Transform _holderPoint;
    [SerializeField] private float _throwStrength;

    private IPlayerInput _input;
    private bool _isCarrying = false;
    private Transform _carryingBox;

    public event Action CarryingStarted;
    public event Action CarryingAborted;

    private void Update()
    {
        if (_isCarrying)
        {
            if (_input.IsInteractButtonPressed() == false)
                return;

            Throw();
        }
    }

    public void Init(IPlayerInput input)
    {
        _input = input != null ? input : throw new ArgumentNullException(nameof(input));
    }

    public void StartCarrying(Transform box)
    {
        if (_isCarrying)
            return;

        _carryingBox = box;
        _carryingBox.SetParent(_holderPoint);
        _carryingBox.localPosition = Vector3.zero;
        _carryingBox.GetComponent<Rigidbody>().useGravity = false;
        _carryingBox.GetComponent<Collider>().enabled = false;
        _isCarrying = true;
        CarryingStarted?.Invoke();
    }

    private void Throw()
    {
        _carryingBox.SetParent(null);
        _carryingBox.GetComponent<Collider>().enabled = true;
        _carryingBox.TryGetComponent(out Rigidbody body);
        body.useGravity = true;
        Vector3 force = (transform.forward + transform.up).normalized * _throwStrength;
        body.AddForce(force);
        _isCarrying = false;
        CarryingAborted?.Invoke();
    }
}
