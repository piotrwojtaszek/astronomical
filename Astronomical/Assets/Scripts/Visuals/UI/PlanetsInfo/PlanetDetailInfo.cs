using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetDetailInfo : MonoBehaviour
{
    [SerializeField]
    SPlanetInfo detail = null;
    [SerializeField]
    TextMeshProUGUI nameField = null;
    [SerializeField]
    TextMeshProUGUI descriptionField = null;
    private void Start()
    {
        nameField.text = detail.name;
        descriptionField.text = "";
        int i = 0;
        foreach (string info in detail.description)
        {
            descriptionField.text += detail.description[i] + '\n';
            i++;
        }

    }
}
