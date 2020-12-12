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
        GUILayout.EndHorizontal();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
