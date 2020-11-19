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
            foreach (Transform element in socket.transform.GetChild(socket.transform.childCount - 1).transform)
            {
                element.name = "DestroyMe";
            }
            socket.ClearLinesList();
            Debug.Log("CLEAING");
        }
        GUILayout.EndHorizontal();
    }
}
