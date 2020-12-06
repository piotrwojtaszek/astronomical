using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetDisplay : MonoBehaviour
{
    public SPlanetInfo planetDetails;
    public TextMeshProUGUI hoverInfo;
    public RectTransform hoverPanel;
    public PlanetsOrbits orbits;
    GameObject planet = null;
    Vector3 oldInfoScale;
    Vector3 offset;
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
        hoverPanel.localScale = oldInfoScale * scale;
        hoverPanel.localPosition = Vector3.up * scale/3f;
        planet.transform.localScale = Vector3.one * SolarSystem.Instance.earthScale * planetDetails.scale;
    }
}