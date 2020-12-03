using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetDisplay : MonoBehaviour
{
    public SPlanetInfo planetDetails;
    public TextMeshProUGUI hoverInfo;
    public Transform hoverPanel;
    public PlanetsOrbits orbits;
    GameObject planet = null;
    Vector3 oldInfoScale;
    private void Start()
    {

        planet = Instantiate(planetDetails.graphic, transform);
        hoverInfo.text = planetDetails.name;
        oldInfoScale = hoverPanel.localScale;
    }

    private void Update()
    {
        if (SolarSystem.Instance.earthOrbitalPeriod != 0.0f)
            orbits.speed = SolarSystem.Instance.earthOrbitalPeriod / planetDetails.speed;
        orbits.a = planetDetails.distanceA * SolarSystem.Instance.earthOrbitDistance;
        orbits.b = planetDetails.distanceB * SolarSystem.Instance.earthOrbitDistance;
        float scale = SolarSystem.Instance.earthScale * planetDetails.scale;
        //scale = Mathf.Clamp(scale, 1f, 5f);
        hoverPanel.localScale = oldInfoScale * scale;
        planet.transform.localScale = Vector3.one * SolarSystem.Instance.earthScale * planetDetails.scale;
    }
}
//jesli ziemia potrzebuje 60 sekund na obiegniecie slona to jesli mars porusza sie wolniej to 60/0.53 