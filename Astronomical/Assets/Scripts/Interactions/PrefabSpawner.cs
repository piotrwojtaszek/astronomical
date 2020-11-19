using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    Transform m_spawnPoint = null;

    [SerializeField]
    private GameObject m_prefabs = null;
    bool isRunning = false;

    public void OnPress()
    {
        if (isRunning == false)
            StartCoroutine(Spawn());
    }


    private IEnumerator Spawn()
    {
        isRunning = true;
        Instantiate(m_prefabs, m_spawnPoint.position, Quaternion.identity);

        yield return new WaitForSeconds(.5f);
        isRunning = false;
    }
}
