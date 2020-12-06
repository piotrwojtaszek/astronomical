using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlanetInfoController : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint = null;

    [SerializeField]
    List<SPlanetInfo> planetInfos = null;

    [SerializeField]
    Transform listContent = null;

    [SerializeField]
    GameObject listButton = null;

    [SerializeField]
    PlanetDetailInfo detailPanel = null;

    [SerializeField]
    SPlanetInfo currentPlanet = null;

    private void Awake()
    {
        foreach (SPlanetInfo info in planetInfos)
        {
            GameObject pref = Instantiate(listButton, listContent);
            pref.GetComponent<UIPlanetButtonList>().planetValue = info;
            pref.GetComponent<UIPlanetButtonList>().infoController = this;


        }
    }

    /// <summary>
    /// Clear spawn point
    /// </summary>
    void Clear()
    {
        currentPlanet = null;
        if (spawnPoint.childCount != 0)
        {
            Destroy(spawnPoint.GetChild(0).gameObject);
            Debug.Log("Planeta została zniszczona");
        }

        //make sure its not empty

        //make it small, very small

        //animation

        //now we can clear it
    }
    /// <summary>
    /// Replace planet details in spawnPoint
    /// </summary>
    public void Replace(SPlanetInfo newPlanet)
    {

        Clear();
        Debug.Log(newPlanet.name);
        currentPlanet = newPlanet;
        detailPanel.UpdatePanel(currentPlanet);
        Instantiate(currentPlanet.graphic, spawnPoint);

        //make sure that scale is very small

        //sign new planet to slot

        //instantiante planet

        //animation

        //now its ready to display informations
    }



}
