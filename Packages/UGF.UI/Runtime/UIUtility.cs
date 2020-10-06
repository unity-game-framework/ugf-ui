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
                Vector2 anchorsMin = Vector2.zero;
                Vector2 anchorsMax = Vector2.zero;

                anchorsMin.x = rectTransform.anchorMin.x + rectTransform.offsetMin.x / rect.width;
                anchorsMin.y = rectTransform.anchorMin.y + rectTransform.offsetMin.y / rect.height;
                anchorsMax.x = rectTransform.anchorMax.x + rectTransform.offsetMax.x / rect.width;
                anchorsMax.y = rectTransform.anchorMax.y + rectTransform.offsetMax.y / rect.height;

                rectTransform.anchorMin = anchorsMin;
                rectTransform.anchorMax = anchorsMax;
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
