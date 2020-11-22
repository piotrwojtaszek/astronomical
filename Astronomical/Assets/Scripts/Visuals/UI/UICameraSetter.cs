using UnityEngine;
[RequireComponent(typeof(Canvas))]
public class UICameraSetter : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
