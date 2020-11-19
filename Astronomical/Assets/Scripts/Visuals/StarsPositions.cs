using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class StarsPositions : MonoBehaviour
{
    public GameObject m_prefab;
    public int m_starsAmount = 10;
    public bool m_clear;
    private List<StarSettings> m_stars = new List<StarSettings>();

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_clear)
        {
            while (transform.childCount != 0)
            {
                foreach (Transform child in transform)
                {
                    DestroyImmediate(child.gameObject);
                }
            }
            m_clear = false;
           
            
        }

    }
    private void LateUpdate()
    {
        if (transform.childCount == 0)
        {
            for (int i = 0; i < m_starsAmount; i++)
            {
                StartCoroutine(Randomm());
            }
        }
    }

    IEnumerator Randomm()
    {
        yield return 0;
        GameObject obj = Instantiate(m_prefab, transform);
        Vector3 randomRotation = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(-179f, 20f), 0f);
        obj.transform.position = new Vector3(0f, 0f, UnityEngine.Random.Range(300f, 500f));
        obj.transform.RotateAround(transform.position, Vector3.right, randomRotation.y);
        obj.transform.RotateAround(transform.position, Vector3.up, randomRotation.x);
        obj.transform.localScale = Vector3.one * UnityEngine.Random.Range(.05f, 2.5f);
    }
}
[Serializable]
public class StarSettings
{
    public Vector3 m_position, m_rotation;
    public float m_scale;
}
