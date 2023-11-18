using UnityEngine;
using UnityEngine.UI;

namespace UGF.UI.Runtime.Components
{
    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("Unity Game Framework/UI/Graphic Empty", 2000)]
    public class GraphicEmptyComponent : Graphic
    {
        public override void SetVerticesDirty()
        {
        }

        public override void SetMaterialDirty()
        {
        }

        protected override void UpdateMaterial()
        {
        }

        protected override void UpdateGeometry()
        {
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
        }

        public override void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
        {
        }

        public override void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB)
        {
        }

        public override void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
        {
        }
    }
}
