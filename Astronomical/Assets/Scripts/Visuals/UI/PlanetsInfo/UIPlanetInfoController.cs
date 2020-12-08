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

    [SerializeField]
    GameObject currentPlanetTransform;

    [SerializeField]
    GameObject listOfPlanets = null;

    [SerializeField]
    bool changePanelsSide = false;

    private void Awake()
    {
        foreach (SPlanetInfo info in planetInfos)
        {
            GameObject pref = Instantiate(listButton, listContent);
            pref.GetComponent<UIPlanetButtonList>().planetValue = info;
            pref.GetComponent<UIPlanetButtonList>().infoController = this;
        }

        detailPanel.gameObject.SetActive(false);

        if (changePanelsSide)
        {
            Vector3 temp = detailPanel.transform.position;
            detailPanel.transform.position = listOfPlanets.transform.position;
            listOfPlanets.transform.position = temp;

        }
    }



    /// <summary>
    /// Clear spawn point
    /// </summary>
    public void Clear()
    {
        currentPlanet = null;
        Destroy(currentPlanetTransform);

        Debug.Log("Planeta została zniszczona");


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
        currentPlanet = newPlanet;
        detailPanel.UpdatePanel(currentPlanet);
        currentPlanetTransform = Instantiate(currentPlanet.graphic, spawnPoint);

        //make sure that scale is very small

        //sign new planet to slot

        //instantiante planet

        //animation

        //now its ready to display informations
    }

    void InfoPanel(bool state)
    {
        detailPanel.gameObject.SetActive(state);
    }

    /// <summary>
    /// check if arg is equal to current active planet
    /// </summary>
    /// <param name="newPlanet"></param>
    /// <returns>If equal return true else false</returns>
    public bool CompareActive(SPlanetInfo newPlanet)
    {
        if (currentPlanet == null || newPlanet != currentPlanet)
        {
            InfoPanel(true);
            return false;
        }
        InfoPanel(false);
        return true;
    }
}
