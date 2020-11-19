using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConsteletionManager))]
public class ConstelationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ConsteletionManager socket = (ConsteletionManager)target;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("CreateLink"))
        {
            socket.CreateConnections();
            Debug.Log("LINKING");
        }
        if (GUILayout.Button("ClearLines"))
        {
            Debug.Log("CLEAING");
        }
        GUILayout.EndHorizontal();
    }
}
