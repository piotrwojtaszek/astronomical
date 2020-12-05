using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScaleSetter : MonoBehaviour
{
    public float sunScale = 20f;

    // Update is called once per frame
    void Update()
    {
        float scale = SolarSystem.Instance.earthScale * sunScale;
        transform.localScale = Vector3.one * scale;
    }
}
