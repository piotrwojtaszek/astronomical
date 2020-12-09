using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayMode : MonoBehaviour
{
    public XRController leftontroller;
    public XRController rightontroller;
    public XRController teleportController;
    // Update is called once per frame
    void Update()
    {
        if (leftontroller)
            leftontroller.gameObject.SetActive(CheckIfActived(leftontroller));
        if (rightontroller)
            rightontroller.gameObject.SetActive(CheckIfActived(rightontroller));
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDeviceCharacteristics rightController = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics leftController = InputDeviceCharacteristics.Left| InputDeviceCharacteristics.Controller;

    }

    public bool CheckIfActived(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, controller.selectUsage, out bool isActived, controller.axisToPressThreshold);
        return isActived;
    }
}
