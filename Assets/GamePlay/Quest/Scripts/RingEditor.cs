using UnityEditor;
using UnityEngine;
namespace Quest
{
    [CustomEditor(typeof(Ring))]
    public class RingEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Ring ring = (Ring)target;
            DrawDefaultInspector();
            if (GUILayout.Button("CreateNextRing"))
                ring.CreateNextRing();
            if (GUILayout.Button("ResetRotetion"))
                ring.ResetRotation();
        }
    }
}
