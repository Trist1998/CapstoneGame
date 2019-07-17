using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: MonoBehaviour
{
    public readonly float DEFAULT_RANGE = 50;

    public abstract void processHit(Item item, GameObject hit, Vector3 direction);

    public virtual void processHit(Item item, GameObject hit)
    {
        processHit(item, hit, new Vector3());
    }

    public virtual void primaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.player.cam.transform.position;
        Vector3 direction = item.player.cam.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            processHit(item, hit.collider.gameObject, direction);
        }
    }

    public virtual void secondaryFire(Item item)
    {}

    public virtual float getRange()
    {
        return DEFAULT_RANGE;
    }
}


