﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class ConsteletionManager : MonoBehaviour
{
    public string constelationName;
    public Connection connectionBuffor = null;

    public List<LineScript> connectionLines;
    public List<Connection> connectionPoints;
    public List<CustomSocket> socketList = new List<CustomSocket>();
    private GameObject linePrefab;


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
        connectionLines.Add(line);
    }

    public void CheckIfSolved()
    {
        int filled = 0;
        foreach(CustomSocket custom in socketList)
        {
            if (custom.isFilled)
                filled++;
        }
        if (filled == socketList.Count)
            Debug.LogWarning("ułożone");
    }

    private void OnDrawGizmos()
    {
        if (connectionPoints != null)
            if (connectionPoints.Count > 0)
                foreach (Connection point in connectionPoints)
                {
#if UNITY_EDITOR
                    Handles.DrawLine(point.pos1.transform.position, point.pos2.transform.position);
#endif
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
