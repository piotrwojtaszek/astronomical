using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScaleSetter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(SolarSystem.Instance.mode==0)
        {
            float scale = SolarSystem.Instance.earthScale/4f * SolarSystem.Instance.sunSize;
            transform.localScale = Vector3.one * scale;
            return;
        }
        if (SolarSystem.Instance.mode == 1)
        {
            transform.localScale = Vector3.one* SolarSystem.Instance.sunSize;
        }
    }
}
