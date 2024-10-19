using DG.Tweening;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition = new Vector3(-4.3f, 2.1f, 1.5f);
    [SerializeField] private Vector3 _endRotation = new Vector3(-39f, 90f, -90f);
    [SerializeField] private Transform _gates;
    [SerializeField] private float _duration = 5;

    private void Start()
    {
        _gates.DOLocalMove(_endPosition, _duration).SetEase(Ease.Linear);
        _gates.DOLocalRotate(_endRotation, _duration).SetEase(Ease.Linear);
    }
}
