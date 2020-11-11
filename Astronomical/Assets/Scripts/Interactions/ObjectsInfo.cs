using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour
{
    public bool picked = false;

    public void SelectEnter()
    {
        picked = true;
    }

    public void SelectExit()
    {
        picked = false;
    }
}
