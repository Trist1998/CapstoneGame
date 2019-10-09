using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScale : AbstractWeaponEffect
{
    public float range;

    /*
     * The weapon effect for maxio
     * Attaches and starts InflateEffect to hit WorldObject if not already attached.
     * If already attached repeat hit is called on attached effect.
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        InflateEffect hitObject = hit.transform.root.GetComponent<InflateEffect>();
        if (hitObject != null)
        {
            hitObject.repeatHit();
            base.processPrimaryHit(item, hit, hitPoint, direction);
        }
        else if(hit.transform.root.GetComponent<WorldObject>() != null)
        {
            hitObject = hit.transform.root.gameObject.AddComponent<InflateEffect>();
            hitObject.startEffect(secondaryOnHitSound);
            base.processPrimaryHit(item, hit, hitPoint, direction);
        }
    }

    public override float getRange()
    {
        return range;
    }
    
}
