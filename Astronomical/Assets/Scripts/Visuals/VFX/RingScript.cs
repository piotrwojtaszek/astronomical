using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    public GameObject prefab;
    public int segments;
    public float xradius;
    public float yradius;
    void Start()
    {
        CreatePoints();
    }


    void CreatePoints()
    {
        float x;
        float z;
        float y = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;
            GameObject obj = Instantiate(prefab);
            Vector3 pos = transform.position;
            obj.transform.position = pos + new Vector3(x, y, z);
            obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, 90f - angle);
            angle += (360f / segments);
        }
    }

}
