using System;
using UnityEngine;

namespace UGF.UI.Runtime
{
    public static class UIUtility
    {
        private static readonly Vector3[] m_corners = new Vector3[4];

        public static void SetAnchorsToCorners(RectTransform rectTransform)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));

            if (rectTransform.parent is RectTransform parent)
            {
                Rect rect = parent.rect;
                Vector2 min = Vector2.zero;
                Vector2 max = Vector2.zero;

                min.x = rectTransform.anchorMin.x + rectTransform.offsetMin.x / rect.width;
                min.y = rectTransform.anchorMin.y + rectTransform.offsetMin.y / rect.height;
                max.x = rectTransform.anchorMax.x + rectTransform.offsetMax.x / rect.width;
                max.y = rectTransform.anchorMax.y + rectTransform.offsetMax.y / rect.height;

                rectTransform.anchorMin = min;
                rectTransform.anchorMax = max;
                rectTransform.offsetMin = Vector2.zero;
                rectTransform.offsetMax = Vector2.zero;
            }
        }

        public static void SetCornersToAnchors(RectTransform rectTransform)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));

            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }

        public static Rect GetWorldRect(Rect rect, Transform transform)
        {
            if (transform == null) throw new ArgumentNullException(nameof(transform));

            Vector2 position = rect.position;
            Vector2 max = rect.max;

            rect.position = transform.TransformPoint(position);
            rect.max = transform.TransformPoint(max);

            return rect;
        }

        public static Rect GetWorldRect(RectTransform rectTransform)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));

            rectTransform.GetWorldCorners(m_corners);

            Rect rect = Rect.zero;

            rect.position = m_corners[0];
            rect.max = m_corners[2];

            return rect;
        }

        public static void SetParentAndFill(Transform parent, RectTransform child)
        {
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            if (child == null) throw new ArgumentNullException(nameof(child));

            child.SetParent(parent, false);
            child.anchorMin = Vector2.zero;
            child.anchorMax = Vector2.one;
            child.offsetMin = Vector2.zero;
            child.offsetMax = Vector2.zero;
        }
    }
}
