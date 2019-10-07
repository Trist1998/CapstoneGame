using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : AttachedEffect
{
    public override void startEffect(float lifeTime)
    {
        GetComponent<RagdollController>()?.ragdoll();
        base.startEffect(lifeTime);
    }

    public override void endEffect()
    {
        WorldObject worldObject = GetComponent<WorldObject>();
        if(worldObject != null && !worldObject.isDead())
            GetComponent<RagdollController>()?.unragdoll();
        base.endEffect();
    }
}
