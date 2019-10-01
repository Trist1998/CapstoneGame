using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : AttachedEffect
{
    public override void startEffect(float lifeTime)
    {
        GetComponent<AICharacter>()?.ragdoll();
        base.startEffect(lifeTime);
    }

    public override void endEffect()
    {
        GetComponent<AICharacter>()?.unragdoll();
        base.endEffect();
    }
}
