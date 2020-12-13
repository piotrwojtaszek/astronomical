using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoonRotator : MonoBehaviour
{
    [SerializeField]
    InputDeviceCharacteristics deviceCharacteristics;
    InputDevice targetDevice;
    [SerializeField] Rigidbody moonPivot;
    [SerializeField] float multiplier;
    [SerializeField] Transform directionalLight;
    [SerializeField] Transform target;//poit where is total eclipse
    void Update()
    {
        if (!targetDevice.isValid)
        {
            UpdateDevices();
        }
        GetValue();

    }

    public void GetValue()
    {
        Vector2 discardedValue;
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out discardedValue))
        {
            moonPivot.AddForce(transform.up * discardedValue.y*multiplier);
            moonPivot.AddForce(transform.right * discardedValue.x*multiplier);
            Debug.Log("Joystic: " + discardedValue);
        }
    }

    void UpdateDevices()
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDeviceCharacteristics controllerCharacteristics = deviceCharacteristics | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);

        foreach (var item in inputDevices)
        {
            Debug.Log(item.name);
        }

        if (inputDevices.Count > 0)
        {
            targetDevice = inputDevices[0];
        }
    }
}
