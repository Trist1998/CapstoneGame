using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetObjectEffect: AttachedObjectEffect
{

    public override void startEffect(float lifeTime)
    {
        base.startEffect(lifeTime);
        appliedStates = new Dictionary<string, int> {[STATE_WET] = 5};
        negatingStates = new Dictionary<string, int>{[STATE_FIRE] = 5};
    }
}
