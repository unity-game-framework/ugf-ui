using UGF.UI.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.UI.Editor
{
    internal static class UIEditorMenu
    {
        [MenuItem("CONTEXT/RectTransform/Anchors/Anchors To Corners", false, 2000)]
        private static void RectTransformAnchorsToCorners(MenuCommand menuCommand)
        {
            var rectTransform = (RectTransform)menuCommand.context;

            Undo.RecordObject(rectTransform, "Anchors To Corners");
            UIUtility.SetAnchorsToCorners(rectTransform);
            EditorUtility.SetDirty(rectTransform);
        }

        [MenuItem("CONTEXT/RectTransform/Anchors/Corners To Anchors", false, 2000)]
        private static void RectTransformCornersToAnchors(MenuCommand menuCommand)
        {
            var rectTransform = (RectTransform)menuCommand.context;

            Undo.RecordObject(rectTransform, "Corners To Anchors");
            UIUtility.SetCornersToAnchors(rectTransform);
            EditorUtility.SetDirty(rectTransform);
        }
    }
}
