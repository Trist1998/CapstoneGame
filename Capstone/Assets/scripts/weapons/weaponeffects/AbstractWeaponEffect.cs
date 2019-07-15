using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: ScriptableObject
{
    public readonly float DEFAULT_RANGE = 50;

    public abstract void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction);
    public abstract void processEffect(GameObject toAffect);

    public virtual void processHit(ObjectPickup shooter, GameObject hit)
    {
        processHit(shooter, hit, new Vector3());
    }

    public virtual void fire(ObjectPickup shooter)
    {
        RaycastHit hit;
        Vector3 origin = shooter.player.cam.transform.position;
        Vector3 direction = shooter.player.cam.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            processHit(shooter, hit.collider.gameObject, direction);
        }
    }

    public virtual float getRange()
    {
        return DEFAULT_RANGE;
    }
}


