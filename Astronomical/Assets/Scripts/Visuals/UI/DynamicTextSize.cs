using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DynamicTextSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Aweke()
    {
        GetComponent<TextMeshProUGUI>().autoSizeTextContainer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
