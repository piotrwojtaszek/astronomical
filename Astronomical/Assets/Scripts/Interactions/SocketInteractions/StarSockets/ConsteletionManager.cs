using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[System.Serializable]
public class ConsteletionManager : MonoBehaviour
{

    public Connection connectionBuffor = null;

    public List<LineScript> connectionLines;

    public List<Connection> connectionPoints;
    GameObject linePrefab;

    private void Start()
    {
        linePrefab = Resources.Load<GameObject>("Prefabs/Others/ConstelationLine");
        CreateConnections();
    }

    public void AddToBufor(CustomSocket currnet)
    {
        if (connectionBuffor.pos1 == null)
        {
            connectionBuffor.pos1 = currnet;
            return;
        }
        if (connectionBuffor.pos2 == null)
        {
            connectionBuffor.pos2 = currnet;
            return;
        }
    }

    public void AddToList()
    {
        if (connectionBuffor.pos1 != null && connectionBuffor.pos2 != null)
        {
            Connection connection = new Connection(connectionBuffor.pos1, connectionBuffor.pos2);
            connectionPoints.Add(connection);
            connectionBuffor.pos1 = null;
            connectionBuffor.pos2 = null;
        }
    }

    public void CreateConnections()
    {
        foreach (Connection point in connectionPoints)
        {
            CreateLine(point.pos1, point.pos2);
        }
    }
    void CreateLine(CustomSocket pos1, CustomSocket pos2)
    {
        GameObject obj = Instantiate(linePrefab, transform.GetChild(transform.childCount - 1).transform);
        LineScript line = obj.GetComponent<LineScript>();
        line.SetPoints(pos1, pos2);
        Debug.Log(pos1 + "   " + pos2);
        connectionLines.Add(line);
    }

    private void OnDrawGizmos()
    {
        foreach (Connection point in connectionPoints)
        {
            Handles.DrawLine(point.pos1.transform.position, point.pos2.transform.position);
        }
    }
}
[System.Serializable]
public class Connection
{
    public CustomSocket pos1;
    public CustomSocket pos2;

    public Connection(CustomSocket _pos1, CustomSocket _pos2)
    {
        pos1 = _pos1;
        pos2 = _pos2;
    }
}
