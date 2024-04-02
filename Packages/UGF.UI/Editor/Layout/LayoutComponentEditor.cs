using UGF.UI.Runtime.Layout;
using UnityEditor;
using UnityEngine;

namespace UGF.UI.Editor.Layout
{
    [CustomEditor(typeof(LayoutComponent), true)]
    public class LayoutComponentEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawControls();
        }

        protected void DrawControls()
        {
            EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                OnDrawControls();
            }
        }

        protected virtual void OnDrawControls()
        {
            if (GUILayout.Button("Calculate", GUILayout.Width(75F)))
            {
                OnCalculate();
            }
        }

        protected virtual void OnCalculate()
        {
            var component = (LayoutComponent)target;

            Undo.RegisterFullObjectHierarchyUndo(component.gameObject, "Layout Calculate");

            component.Calculate();
        }
    }
}
