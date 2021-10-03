using System;
using UnityEngine;

namespace UGF.UI.Runtime
{
    public static class UIUtility
    {
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
    }
}
