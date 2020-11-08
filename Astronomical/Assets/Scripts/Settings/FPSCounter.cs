using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    TextMeshProUGUI napis;
    // Start is called before the first frame update
    void Start()
    {
        napis = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Refresh());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Refresh()
    {
        for (; ; )
        {
            int current = (int)(1f / Time.unscaledDeltaTime);
            napis.text = current.ToString() + " FPS ";
            yield return new WaitForSeconds(1f);
        }

    }
}
