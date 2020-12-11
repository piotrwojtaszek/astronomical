using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public static SolarSystem Instance;
    public float earthOrbitalPeriod = 60f;
    public float earthScale = 1f;
    public float earthOrbitDistance = 1f;
    public float solarScale = 1f;
    public float solarSpeed = 1f;
    [Tooltip("0-realistyczny, 1-symboliczny, 2-hybryda")]
    public int mode = 0;
    public float sunSize = 8f;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        transform.localScale = Vector3.one * solarScale;
    }
}
