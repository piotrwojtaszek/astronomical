using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookTowardCamera : MonoBehaviour
{
    Transform playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 upAxis = Vector3.up;
        Vector3 relativePos = playerCam.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, upAxis);
        transform.rotation = new Quaternion(transform.rotation.x,rotation.y,transform.rotation.z,rotation.w);
    }
}
