using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlanetsShadow : MonoBehaviour
{
    [SerializeField]
    Transform parent = null;
    public Vector3 offset;
    // Update is called once per frame
    private void Start()
    {
        offset = transform.position - parent.position;
    }
    void Update()
    {
        transform.position = parent.position + offset;
    }
}
