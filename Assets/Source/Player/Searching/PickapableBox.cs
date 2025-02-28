using UnityEngine;
using UnityEngine.EventSystems;

public class PickapableBox : MonoBehaviour, IPointerClickHandler
{
    private float _pickupDistance;
    private Carrier _player;

    public void OnPointerClick(PointerEventData eventData)
    {
        var distance = (transform.position - _player.transform.position).magnitude;

        if (distance < _pickupDistance)
            _player.StartCarrying(transform);
    }

    public void Init(Carrier player, float distance)
    {
        _pickupDistance = distance > 0 ? distance :  throw new System.ArgumentOutOfRangeException(nameof(distance));
        _player = player != null ? player : throw new System.ArgumentNullException(nameof(player));
    }
}
