using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGF.UI.Runtime.Layout
{
    public static class LayoutRectTransformUtility
    {
        public static void FitInParent(RectTransform rectTransform)
        {
            Vector2 size = rectTransform.rect.size;

            FitInParent(rectTransform, size.x / size.y);
        }

        public static void FitInParent(RectTransform rectTransform, float aspectRatio)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));

            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchoredPosition = Vector2.zero;

            Vector2 size = Vector2.zero;
            var parent = rectTransform.parent as RectTransform;
            Vector2 parentSize = parent != null ? parent.rect.size : Vector2.zero;

            if (parentSize.y * aspectRatio > parentSize.x)
            {
                size.y = parentSize.x / aspectRatio - parentSize.y;
            }
            else
            {
                size.x = parentSize.y * aspectRatio - parentSize.x;
            }

            rectTransform.sizeDelta = size;
        }

        public static void SetSizeFromImage(RectTransform rectTransform, Image image)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));
            if (image == null) throw new ArgumentNullException(nameof(image));

            float x = image.sprite.rect.width / image.pixelsPerUnit;
            float y = image.sprite.rect.height / image.pixelsPerUnit;

            rectTransform.anchorMax = rectTransform.anchorMin;
            rectTransform.sizeDelta = new Vector2(x, y);
        }
    }
}
