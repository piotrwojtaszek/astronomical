using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class StarSpawner : MonoBehaviour
{
    List<InputDevice> inputDevices = new List<InputDevice>();
    bool spawnPossible = true;
    [SerializeField] GameObject m_prefab = null;
    [SerializeField] GameObject m_socketPrefab = null;
    [SerializeField] GameObject m_socket = null;
    Transform cam;
    List<XRBaseInteractable> lista = new List<XRBaseInteractable>();
    private void Start()
    {
        cam = Camera.main.transform;
        StartCoroutine(UpdateDevices());
    }

    void Update()
    {
        RecordInput();
        /*if(m_socket.gameObject.activeSelf)
        {
            m_socket.GetComponent<XRSocketInteractor>().GetValidTargets(lista);
            if(lista.Count==0)
            {
                m_socket.gameObject.SetActive(false);
            }
        }*/
    }

    void RecordInput()
    {
        foreach (InputDevice device in inputDevices)
        {
            InputHelpers.IsPressed(device, InputHelpers.Button.PrimaryButton, out bool isPressed);
            if (isPressed)
            {
                if (spawnPossible)
                {
                    StartCoroutine(Spawn());
                    Debug.Log("pressed");
                }

            }
        }
    }

    IEnumerator Spawn()
    {
        spawnPossible = false;
        Follow();
        m_socket = Instantiate(m_socketPrefab, transform);
        Instantiate(m_prefab, m_socket.transform.position + Vector3.up, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Destroy(m_socket);
        yield return new WaitForSeconds(1f);
        spawnPossible = true;
    }

    void Follow()
    {
        transform.position = cam.position + new Vector3(cam.forward.x / 3f, -0.25f, cam.forward.z / 3f);
    }

    IEnumerator UpdateDevices()
    {
        for (; ; )
        {
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, inputDevices);
            foreach (var device in inputDevices)
            {
                Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
            }
            yield return new WaitForSeconds(5f);
        }


    }
}
