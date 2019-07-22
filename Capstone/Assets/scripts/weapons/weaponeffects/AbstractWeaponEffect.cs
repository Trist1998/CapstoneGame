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
    
    public virtual void processSecondaryHit(Item item, GameObject hit)
    {
        processSecondaryHit(item, hit, new Vector3(), new Vector3());
    }
    
    public virtual void primaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.user.getUserAimPosition();
        Vector3 direction = item.user.getUserAimDirection();

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            if(hit.transform.root != item.transform.root)
                processPrimaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

    public virtual void secondaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.user.getUserAimPosition();
        Vector3 direction = item.user.getUserAimDirection();

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            if(hit.transform.root != item.transform.root)
                processSecondaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

    public virtual float getRange()
    {
        return DEFAULT_RANGE;
    }
}


