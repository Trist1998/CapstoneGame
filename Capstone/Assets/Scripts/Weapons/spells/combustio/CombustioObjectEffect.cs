using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustioObjectEffect : AttachedObjectEffect
{
    public override void startEffect(float lifeTime)
    {
        appliedStates[STATE_FUEL] = 5;
        negatingStates[STATE_WET] = 5;
        base.startEffect(lifeTime);
    }
}
