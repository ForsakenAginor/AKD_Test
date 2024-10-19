using UnityEngine;

public class Box : MonoBehaviour
{
    const string IsWorking = "_IsWorking";

    [SerializeField] private Material _materialWithOutline;

    public bool IsSelected { get; private set; }

    private void Start()
    {
        DeSelect();
    }

    public void Select()
    {
        IsSelected = true;
        _materialWithOutline.SetInt(IsWorking, 1);
    }

    public void DeSelect()
    {
        IsSelected = false;
        _materialWithOutline.SetInt(IsWorking, 0);
    }
}
