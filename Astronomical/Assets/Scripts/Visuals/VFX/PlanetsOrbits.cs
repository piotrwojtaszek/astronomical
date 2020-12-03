using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlanetsOrbits : MonoBehaviour
{
    public float a = 1f; //a is in AU, Semimajor Axis
    private float angle; // angle theta
    [Tooltip("Ile sekund zajmuje pelen obrot")]
    public float speed = 1f;
    private float calculatedSpeed = 1f;
    float x;
    float z;
    public float b = 1f;
    private void Start()
    {

    }
    void Update()
    {
        calculatedSpeed = (2 * Mathf.PI) / speed;
        angle += calculatedSpeed * Time.deltaTime;
        x = Mathf.Cos(angle) * a * transform.lossyScale.x + SolarSystem.Instance.transform.position.x; // a is the Radius in the x direction
        z = Mathf.Sin(angle) * b * transform.lossyScale.x + SolarSystem.Instance.transform.position.z; // b is the  Radius in the z direction
        transform.position = new Vector3(x, 0 + transform.position.y, z);
    }
}
