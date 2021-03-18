using UnityEngine;
using UnityEditor;

namespace Quest
{
    // ˜˜˜˜ ˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜ ˜˜˜ ˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜˜ ˜˜˜˜˜˜ ˜˜˜˜˜˜˜˜˜
    [CustomEditor(typeof(Checkpoint))]
    public class CheckpointEditor : Editor
    {
        private SerializedProperty id;
        private Checkpoint checkpoint;
        private void OnEnable()
        {
            id = serializedObject.FindProperty("id");
            checkpoint = (Checkpoint)target;
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(id);
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("CreateNextRing"))
            {
                checkpoint.CreateNextCheckpoint();
            }
        }
    }
}
