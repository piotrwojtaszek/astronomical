using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetColorRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void SetColorBlue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
