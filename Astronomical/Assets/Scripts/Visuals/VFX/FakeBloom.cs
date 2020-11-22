using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBloom : MonoBehaviour
{
    Transform playerCam;
    void Start()
    {
        playerCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCam);
    }
}
