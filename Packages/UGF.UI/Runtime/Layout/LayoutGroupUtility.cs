using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    public static class LayoutGroupUtility
    {
        public static void CalculateSize(RectTransform rectTransform, IReadOnlyList<Rect> rects, LayoutSettings settings)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));
            if (rects == null) throw new ArgumentNullException(nameof(rects));

            int axisAlongIndex = GetAxisAlongIndex(settings.Direction);
            int axisCrossIndex = GetAxisCrossIndex(settings.Direction);

            float axisAlongSize = settings.PaddingStart + settings.PaddingEnd;
            float axisCrossSize = 0F;

            for (int i = 0; i < rects.Count; i++)
            {
                Rect rect = rects[i];
                float rectAlongSize = rect.size[axisAlongIndex];
                float rectCrossSize = rect.size[axisCrossIndex];

                axisAlongSize += rectAlongSize;

                if (rects.Count > 1 && i < rects.Count - 1)
                {
                    axisAlongSize += settings.Spacing;
                }

                if (axisCrossSize < rectCrossSize)
                {
                    axisCrossSize = rectCrossSize;
                }
            }

            if (settings.AdjustSizeAlongDirection)
            {
                float min = settings.UseMinSizeAlongDirection ? settings.MinSizeAlongDirection : 0F;
                float max = settings.UseMaxSizeAlongDirection ? settings.MaxSizeAlongDirection : float.MaxValue;

                rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axisAlongIndex, Mathf.Clamp(axisAlongSize, min, max));
            }

            if (settings.AdjustSizeCrossDirection)
            {
                rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axisCrossIndex, axisCrossSize);
            }
        }

        public static void CalculatePositions(RectTransform rectTransform, IList<Rect> rects, LayoutSettings settings)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));
            if (rects == null) throw new ArgumentNullException(nameof(rects));

            int axisIndex = GetAxisAlongIndex(settings.Direction);
            float axisPosition;

            if (settings.Reverse)
            {
                axisPosition = settings.PaddingEnd;

                for (int i = rects.Count - 1; i >= 0; i--)
                {
                    Rect rect = rects[i];

                    axisPosition = SetAxisPosition(ref rect, axisIndex, axisPosition);

                    if (rects.Count > 1 && i > 0)
                    {
                        axisPosition += settings.Spacing;
                    }

                    rects[i] = rect;
                }

                axisPosition += settings.PaddingStart;
            }
            else
            {
                axisPosition = settings.PaddingStart;

                for (int i = 0; i < rects.Count; i++)
                {
                    Rect rect = rects[i];

                    axisPosition = SetAxisPosition(ref rect, axisIndex, axisPosition);

                    if (rects.Count > 1 && i < rects.Count - 1)
                    {
                        axisPosition += settings.Spacing;
                    }

                    rects[i] = rect;
                }

                axisPosition += settings.PaddingEnd;
            }

            float axisAlignmentOffset = settings.Alignment switch
            {
                LayoutDirectionAlignment.Start => rectTransform.sizeDelta[axisIndex] * -0.5F,
                LayoutDirectionAlignment.Center => axisPosition * -0.5F,
                LayoutDirectionAlignment.End => rectTransform.sizeDelta[axisIndex] * 0.5F - axisPosition,
                _ => throw new ArgumentOutOfRangeException(nameof(settings.Alignment), "Layout direction alignment is unknown.")
            };

            for (int i = 0; i < rects.Count; i++)
            {
                Rect rect = rects[i];
                Vector2 rectPosition = rect.position;

                rectPosition[axisIndex] += axisAlignmentOffset;

                rect.position = rectPosition;
                rects[i] = rect;
            }
        }

        public static void AlignInParent(RectTransform rectTransform, RectTransform parent, LayoutDirection direction, bool reverse)
        {
            if (rectTransform == null) throw new ArgumentNullException(nameof(rectTransform));
            if (parent == null) throw new ArgumentNullException(nameof(parent));

            int axisAlongIndex = GetAxisAlongIndex(direction);
            float axisAlongSize = rectTransform.rect.size[axisAlongIndex];
            float parentAlongSize = parent.rect.size[axisAlongIndex];

            float parentAlignment = parentAlongSize < axisAlongSize
                ? reverse
                    ? 1F
                    : 0F
                : 0.5F;

            Vector2 position = rectTransform.anchoredPosition;
            Vector2 anchorMin = rectTransform.anchorMin;
            Vector2 anchorMax = rectTransform.anchorMax;
            Vector2 pivot = rectTransform.pivot;

            position[axisAlongIndex] = 0F;
            anchorMin[axisAlongIndex] = parentAlignment;
            anchorMax[axisAlongIndex] = parentAlignment;
            pivot[axisAlongIndex] = parentAlignment;

            rectTransform.anchoredPosition = position;
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.pivot = pivot;
        }

        public static int GetAxisAlongIndex(LayoutDirection direction)
        {
            return direction switch
            {
                LayoutDirection.Horizontal => 0,
                LayoutDirection.Vertical => 1,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Layout direction is unknown.")
            };
        }

        public static int GetAxisCrossIndex(LayoutDirection direction)
        {
            return direction switch
            {
                LayoutDirection.Horizontal => 1,
                LayoutDirection.Vertical => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Layout direction is unknown.")
            };
        }

        private static float SetAxisPosition(ref Rect rect, int axisIndex, float axisPosition)
        {
            float rectSize = rect.size[axisIndex];
            Vector2 rectPosition = Vector2.zero;

            rectPosition[axisIndex] = axisPosition + rectSize * 0.5F;
            rect.position = rectPosition;

            axisPosition += rectSize;

            return axisPosition;
        }
    }
}
