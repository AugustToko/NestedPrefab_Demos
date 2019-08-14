using UnityEngine;
using UnityEngine.UI;

public class UIParticles : MaskableGraphic
{
    public ParticleSystemRenderer particleSystemRenderer;
    public bool useTransform;
    public Texture texture;

    private void Update()
    {
        SetVerticesDirty();
    }

    public override Texture mainTexture => texture ? texture : base.mainTexture;

    protected override void OnPopulateMesh(Mesh m)
    {
        if (particleSystemRenderer)
        {
            particleSystemRenderer.BakeMesh(m, useTransform);
            //particleSystemRenderer.BakeTrailsMesh
        }
    }
}
