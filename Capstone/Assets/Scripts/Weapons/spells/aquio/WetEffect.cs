using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetEffect: AttachedEffect
{

    public void startEffect(float lifeTime)
    {
        appliedStates[AttachedEffectManager.STATE_WET] = 5;
        negatingStates[AttachedEffectManager.STATE_FIRE] = 5;
        base.startEffect(gameObject, lifeTime);
    }
}
