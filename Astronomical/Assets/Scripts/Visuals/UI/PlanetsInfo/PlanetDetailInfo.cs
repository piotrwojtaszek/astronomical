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
        descriptionField.text = detail.description[0];
    }
}
