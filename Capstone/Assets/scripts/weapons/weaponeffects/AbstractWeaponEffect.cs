using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: MonoBehaviour
{
    public const float DEFAULT_RANGE = 50;

    public abstract void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction);
    public virtual void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {}
    
    public virtual void processPrimaryHit(Item item, GameObject hit)
    {
        processPrimaryHit(item, hit, new Vector3(), new Vector3());
    }
    
    public virtual void primaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.player.cam.transform.position;
        Vector3 direction = item.player.cam.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            processPrimaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

    public virtual void secondaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.player.cam.transform.position;
        Vector3 direction = item.player.cam.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            processSecondaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

    public virtual float getRange()
    {
        return DEFAULT_RANGE;
    }
}


