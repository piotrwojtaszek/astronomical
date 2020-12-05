using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetDetailInfo : MonoBehaviour
{
    [SerializeField]
    SPlanetInfo detail;
    [SerializeField]
    TextMeshProUGUI nameField;
    [SerializeField]
    TextMeshProUGUI descriptionField;
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
