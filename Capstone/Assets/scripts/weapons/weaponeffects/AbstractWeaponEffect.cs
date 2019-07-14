using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: ScriptableObject
{
    public void processHit(ObjectPickup shooter, GameObject hit)
    {
        processHit(shooter, hit, new Vector3());
    }
    public abstract void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction);
    public abstract void processEffect(GameObject toAffect);
    public abstract void fire(ObjectPickup shooter);
}


