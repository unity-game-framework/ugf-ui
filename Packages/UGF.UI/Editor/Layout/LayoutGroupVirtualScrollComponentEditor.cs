using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.UI.Runtime.Layout;
using UnityEditor;
using UnityEngine;

namespace UGF.UI.Editor.Layout
{
    [CustomEditor(typeof(LayoutGroupVirtualScrollComponent), true)]
    internal class LayoutGroupVirtualScrollComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScroll;
        private SerializedProperty m_propertyLayout;
        private SerializedProperty m_propertyViewportPadding;
        private SerializedProperty m_propertyEntryDefaultSize;

        private readonly GUIContent m_contentViewportPaddingLabel = new GUIContent("Viewport Padding");

        private readonly GUIContent[] m_contentViewportPaddingLabels =
        {
            new GUIContent("Left"),
            new GUIContent("Right"),
            new GUIContent("Top"),
            new GUIContent("Bottom")
        };

        private void OnEnable()
        {
            m_propertyScroll = serializedObject.FindProperty("m_scroll");
            m_propertyLayout = serializedObject.FindProperty("m_layout");
            m_propertyViewportPadding = serializedObject.FindProperty("m_viewportPadding");
            m_propertyEntryDefaultSize = serializedObject.FindProperty("m_entryDefaultSize");
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyScroll);
                EditorGUILayout.PropertyField(m_propertyLayout);

                EditorGUI.MultiPropertyField(EditorGUILayout.GetControlRect(true), m_contentViewportPaddingLabels, m_propertyViewportPadding.FindPropertyRelative("x"), m_contentViewportPaddingLabel);

                EditorGUILayout.PropertyField(m_propertyEntryDefaultSize);
            }
        }
    }
}
