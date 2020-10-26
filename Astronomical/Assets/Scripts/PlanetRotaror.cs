using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotaror : MonoBehaviour
{
    public Transform m_pivot;
    public float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(m_pivot.position, Vector3.up, m_speed*Time.deltaTime);
    }
}
