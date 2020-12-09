using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayMode : MonoBehaviour
{
    public XRController rayInteractor;
    public XRController teleportController;
    [SerializeField]
    InputDeviceCharacteristics deviceCharacteristics;
    InputDevice targetDevice;

    void Update()
    {
        if (!targetDevice.isValid)
        {
            UpdateDevices();
        }



        rayInteractor.gameObject.SetActive(!CheckIfActived());
        teleportController.gameObject.SetActive(CheckIfActived());





    }

    public bool CheckIfActived()
    {
        InputHelpers.IsPressed(targetDevice, InputHelpers.Button.PrimaryAxis2DUp, out bool isActived, 0.75f);
        return isActived;
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
