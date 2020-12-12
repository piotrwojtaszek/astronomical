using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
[CustomEditor(typeof(ConsteletionManager))]
[ExecuteAlways]
public class ConstelationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ConsteletionManager socket = (ConsteletionManager)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add to buffor"))
        {
            if(Selection.activeGameObject!=null)
            {
                socket.AddToBufor(Selection.activeGameObject.GetComponent<CustomSocket>());
            }
        }
        if (GUILayout.Button("Make connection"))
        {
            socket.AddToList();     
        }
        if (GUILayout.Button("Add Point"))
        {
            if (socket.transform.childCount < 1)
            {
                Instantiate(new GameObject("Sockets"), socket.transform);
                Instantiate(new GameObject("Lines"), socket.transform);
            }
            GameObject socektPrefab = Resources.Load<GameObject>("Prefabs2/Interactable/Sockets/CustomSocket");
            Instantiate(socektPrefab, socket.transform.GetChild(0).transform);
        }
        GUILayout.EndHorizontal();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
