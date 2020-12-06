using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlanetButtonList : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SPlanetInfo planetValue = null;
    public UIPlanetInfoController infoController = null;
    private void Start()
    {
        if (planetValue != null)
            text.text = planetValue.name;
        else
            Debug.LogWarning("No assigned planet");
        GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {
        if (planetValue != null)
            infoController.Replace(planetValue);
        else
            Debug.LogWarning("No assigned planet");
    }
}
