using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsteletionManager : MonoBehaviour
{
    public List<LineScript> connectionLines = null;

    public List<Connection> connectionPoints;
    public void CreateConnections()
    {
        foreach (Connection point in connectionPoints)
        {
            CreateLine(point.pos1, point.pos2);
        }
    }
    void CreateLine(CustomSocket pos1, CustomSocket pos2)
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/Others/ConstelationLine");
        Instantiate(obj, transform.GetChild(transform.childCount - 1).transform);
        LineScript line = obj.GetComponent<LineScript>();
        line.SetPoints(pos1, pos2);
        connectionLines.Add(line);
    }

    public void ClearLinesList()
    {
        connectionLines.Clear();
    }
}
[System.Serializable]
public class Connection
{
    public CustomSocket pos1;
    public CustomSocket pos2;
}
