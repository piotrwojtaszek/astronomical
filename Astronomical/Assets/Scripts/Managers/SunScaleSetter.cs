using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScaleSetter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

            transform.localScale = Vector3.one * SolarSystem.Instance.sunSize;
            return;
    }
}
