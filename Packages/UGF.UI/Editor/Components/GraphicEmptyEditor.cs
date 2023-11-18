using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.UI.Runtime.Components;
using UnityEditor;

namespace UGF.UI.Editor.Components
{
    [CustomEditor(typeof(GraphicEmpty), true)]
    internal class GraphicEmptyEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyRaycastTarget;
        private SerializedProperty m_propertyRaycastPadding;

        private void OnEnable()
        {
            m_propertyRaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
            m_propertyRaycastPadding = serializedObject.FindProperty("m_RaycastPadding");
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyRaycastTarget);
                EditorGUILayout.PropertyField(m_propertyRaycastPadding);
            }
        }
    }
}
