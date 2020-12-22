using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// This class is responsible for planet behaviour while orbits around sun
/// </summary>
public class PlanetDisplay : MonoBehaviour
{
    SphereCollider collider;
    public SPlanetInfo planetDetails;
    public TextMeshProUGUI hoverInfo;
    public RectTransform hoverPanel;
    public PlanetsOrbits orbits;
    GameObject planet = null;
    Vector3 oldInfoScale;
    float uiScale = 1f;
    private void Start()
    {
        planet = Instantiate(planetDetails.graphic, transform);
        hoverInfo.text = planetDetails.name;
        oldInfoScale = hoverPanel.localScale;
        planet.transform.eulerAngles = new Vector3(0f, 0f, planetDetails.tilt);
        collider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        collider.radius = 0.51f* SolarSystem.Instance.earthScale * planetDetails.scale;
        planet.transform.Rotate(transform.up, (Time.deltaTime / planetDetails.rotationSpeed) * SolarSystem.Instance.solarSpeed);
        //ZŁOŻONY REALISTYCZNY
        if (SolarSystem.Instance.mode == 0)
        {
            if (SolarSystem.Instance.earthOrbitalPeriod != 0.0f)
                orbits.speed = SolarSystem.Instance.earthOrbitalPeriod / planetDetails.speed / SolarSystem.Instance.solarSpeed;
            orbits.a = planetDetails.distanceA * SolarSystem.Instance.earthOrbitDistance;
            orbits.b = planetDetails.distanceB * SolarSystem.Instance.earthOrbitDistance;
            float scale = SolarSystem.Instance.earthScale * planetDetails.scale;
            uiScale = scale;
            uiScale = Mathf.Clamp(uiScale, 1f, 5f);
            hoverPanel.localScale = oldInfoScale*uiScale;
            hoverPanel.localPosition = Vector3.up * scale/3f;
            planet.transform.localScale = Vector3.one * SolarSystem.Instance.earthScale * planetDetails.scale;
            return;
        }
        //SYMBOLICZNY UPROSZCZONY
        if (SolarSystem.Instance.mode == 1)
        {
            if (SolarSystem.Instance.earthOrbitalPeriod != 0.0f)
                orbits.speed = SolarSystem.Instance.earthOrbitalPeriod / planetDetails.speed / SolarSystem.Instance.solarSpeed;
            orbits.a = planetDetails.place * SolarSystem.Instance.earthOrbitDistance;
            orbits.b = planetDetails.place * SolarSystem.Instance.earthOrbitDistance;
            hoverPanel.localScale = oldInfoScale;
            hoverPanel.localPosition = Vector3.up / 5f;
            planet.transform.localScale = Vector3.one * SolarSystem.Instance.earthScale;
            return;
        }
        //SYMBOLICZNY REALISTYCZNY
        if (SolarSystem.Instance.mode == 2)
        {
            if (SolarSystem.Instance.earthOrbitalPeriod != 0.0f)
                orbits.speed = SolarSystem.Instance.earthOrbitalPeriod / planetDetails.speed / SolarSystem.Instance.solarSpeed;
            orbits.a = planetDetails.place * SolarSystem.Instance.earthOrbitDistance;
            orbits.b = planetDetails.place * SolarSystem.Instance.earthOrbitDistance;
            float scale = SolarSystem.Instance.earthScale * planetDetails.scale;
            uiScale = scale;
            uiScale = Mathf.Clamp(uiScale, 1f, 5f);
            hoverPanel.localScale = oldInfoScale * uiScale;
            hoverPanel.localPosition = Vector3.up * scale / 3f;
            planet.transform.localScale = Vector3.one * SolarSystem.Instance.earthScale * planetDetails.scale;
            return;
        }

    }
}