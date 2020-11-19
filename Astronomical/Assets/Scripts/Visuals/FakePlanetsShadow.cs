using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlanetsShadow : MonoBehaviour
{
    [SerializeField]
    Transform parent = null;
    [SerializeField]

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.position;
    }
}
