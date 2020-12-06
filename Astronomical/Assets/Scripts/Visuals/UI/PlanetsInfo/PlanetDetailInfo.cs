using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetDetailInfo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameField = null;
    [SerializeField]
    TextMeshProUGUI descriptionField = null;

    public void UpdatePanel(SPlanetInfo detail)
    {
        if (detail)
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
}
