using System;
using UnityEngine;

[RequireComponent(typeof(BoxSearcher))]
public class Carrier : MonoBehaviour
{
    [SerializeField] private Transform _holderPoint;
    [SerializeField] private float _throwStrength;

    private BoxSearcher _searcher;
    private IPlayerInput _input;
    private bool _isCarrying = false;
    private Transform _carryingBox;

    public event Action CarryingStarted;
    public event Action CarryingAborted;


    private void Awake()
    {
        _searcher = GetComponent<BoxSearcher>();
    }

    private void Update()
    {
        if (_isCarrying)
        {
            if (_input.IsInteractButtonPressed() == false)
                return;

            Throw();
            return;
        }

        if (_searcher.SelectedBox == null)
            return;

        if (_input.IsInteractButtonPressed() == false)
            return;

        _carryingBox = _searcher.SelectedBox.transform;
        StartCarrying();
    }

    public void Init(IPlayerInput input)
    {
        _input = input != null ? input : throw new ArgumentNullException(nameof(input));
    }

    private void StartCarrying()
    {
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
