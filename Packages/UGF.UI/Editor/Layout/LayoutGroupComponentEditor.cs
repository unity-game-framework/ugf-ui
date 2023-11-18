using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.UI.Runtime.Layout;
using UnityEditor;

namespace UGF.UI.Editor.Layout
{
    [CustomEditor(typeof(LayoutGroupComponent), true)]
    internal class LayoutGroupComponentEditor : LayoutCollectionComponentEditor
    {
        private SerializedProperty m_propertyRoot;
        private SerializedProperty m_propertySettings;
        private SerializedProperty m_propertyParentRelativeAlignment;
        private SerializedProperty m_propertyIgnoreInactive;
        private SerializedProperty m_propertyIgnoreZeroLength;
        private ReorderableListDrawer m_listIgnore;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_propertyRoot = serializedObject.FindProperty("m_root");
            m_propertySettings = serializedObject.FindProperty("m_settings");
            m_propertyParentRelativeAlignment = serializedObject.FindProperty("m_parentRelativeAlignment");
            m_propertyIgnoreInactive = serializedObject.FindProperty("m_ignoreInactive");
            m_propertyIgnoreZeroLength = serializedObject.FindProperty("m_ignoreZeroLength");
            m_listIgnore = new ReorderableListDrawer(serializedObject.FindProperty("m_ignore"));
            m_listIgnore.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            m_listIgnore.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyRoot);
                EditorGUILayout.PropertyField(m_propertySettings);
                EditorGUILayout.PropertyField(m_propertyParentRelativeAlignment);
                EditorGUILayout.PropertyField(m_propertyIgnoreInactive);
                EditorGUILayout.PropertyField(m_propertyIgnoreZeroLength);

                m_listIgnore.DrawGUILayout();

                DrawCollection();
            }

            DrawControls();
        }
    }
}
