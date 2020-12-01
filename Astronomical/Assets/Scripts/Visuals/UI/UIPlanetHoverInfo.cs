using UnityEngine;

public class UIPlanetHoverInfo : MonoBehaviour
{
    public GameObject canvas;
    public void Select()
    {
        canvas.SetActive(true);
    }
    public void UnSelect()
    {
        canvas.SetActive(false);
    }
}
