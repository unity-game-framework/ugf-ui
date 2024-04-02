using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.UI.Runtime.Layout;
using UnityEditor;
using UnityEngine;

namespace UGF.UI.Editor.Layout
{
    [CustomEditor(typeof(LayoutCollectionComponent), true)]
    internal class LayoutCollectionComponentEditor : LayoutComponentEditor
    {
        private ReorderableListDrawer m_listLayouts;

        protected virtual void OnEnable()
        {
            m_listLayouts = new ReorderableListDrawer(serializedObject.FindProperty("m_layouts"));
            m_listLayouts.Enable();
        }

        protected virtual void OnDisable()
        {
            m_listLayouts.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                DrawCollection();
            }

            DrawControls();
        }

        protected void DrawCollection()
        {
            m_listLayouts.DrawGUILayout();
        }

        protected override void OnDrawControls()
        {
            using (new EditorGUI.DisabledScope(m_listLayouts.SerializedProperty.arraySize == 0))
            {
                if (GUILayout.Button("Clear", GUILayout.Width(75F)))
                {
                    OnClear();
                }
            }

            if (GUILayout.Button("Collect", GUILayout.Width(75F)))
            {
                OnCollect();
            }

            base.OnDrawControls();
        }

        private void OnCollect()
        {
            m_listLayouts.SerializedProperty.ClearArray();

            LayoutComponent[] components = ((Component)target).GetComponentsInChildren<LayoutComponent>(true);

            for (int i = 0; i < components.Length; i++)
            {
                LayoutComponent component = components[i];

                if (component != target)
                {
                    m_listLayouts.SerializedProperty.InsertArrayElementAtIndex(m_listLayouts.SerializedProperty.arraySize);

                    SerializedProperty propertyElement = m_listLayouts.SerializedProperty.GetArrayElementAtIndex(m_listLayouts.SerializedProperty.arraySize - 1);

                    propertyElement.objectReferenceValue = component;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void OnClear()
        {
            m_listLayouts.SerializedProperty.ClearArray();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
