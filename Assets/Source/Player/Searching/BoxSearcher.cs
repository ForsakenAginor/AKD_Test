using UnityEngine;

public class BoxSearcher : MonoBehaviour
{
    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private float _distance;

    private Box _selectedBox;

    public Box SelectedBox => _selectedBox;

    private void FixedUpdate()
    {
        var results = Physics.RaycastAll(_rayOrigin.position, _rayOrigin.forward, _distance);
        Box box = null;

        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].collider.TryGetComponent(out box))
                break;
        }

        if (box == null || (_selectedBox != null && box != _selectedBox))
        {
            DeselectBox();
            return;
        }

        _selectedBox = box;

        if (_selectedBox.IsSelected == false)
            _selectedBox.Select();
    }

    private void DeselectBox()
    {
        if (_selectedBox != null)
        {
            _selectedBox.DeSelect();
            _selectedBox = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_rayOrigin.position, _rayOrigin.position + _rayOrigin.forward * 5);
    }
}
