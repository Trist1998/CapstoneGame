using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustioObjectEffect : AttachedObjectEffect
{
    public override void affectObject()
    {
        IgniteObjectEffect ignite = gameObject.GetComponent<IgniteObjectEffect>();
        if (ignite == null) return;
        ignite.getLifeTimer().setLifeTime(10);
        endEffect();
    }

    public override void startEffect(float lifeTime)
    {
        appliedStates[STATE_FUEL] = 5;
        negatingStates[STATE_WET] = 5;
        base.startEffect(lifeTime);
    }
}
