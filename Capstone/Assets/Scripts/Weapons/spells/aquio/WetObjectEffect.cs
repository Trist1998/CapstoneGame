using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetObjectEffect: AttachedObjectEffect
{

    public override void startEffect(float lifeTime)
    {
        appliedStates[STATE_WET] = 5;
        negatingStates[STATE_FIRE] = 5;
        base.startEffect(lifeTime);
    }
}
