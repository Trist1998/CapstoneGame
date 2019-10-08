using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEffect : AttachedEffect
{
    private float healthPerSecond;
    private WorldObject obj;

    public void startEffect(WorldObject hit, int hitPointsToAdd, float lifetime)
    {
        obj = hit;
        healthPerSecond = hitPointsToAdd/lifetime;
        base.startEffect(lifetime);
    }

    public override void affectObject()
    {
        obj.heal( healthPerSecond * Time.deltaTime);
    }
    
    
}
