using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPlanet", menuName = "MyObjects/NewPlanet")]
public class SPlanetInfo : ScriptableObject
{
    public new string name;
    public float scale;
    public float distanceA, distanceB;
    public float speed;
    public float mass;
    [TextArea(2, 20)]
    public string[] description;
    public GameObject graphic;
}
