using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttract : AbstractWeaponEffect
{
    private AttractEffect other;
    public float effectLifeTime;
    public float force;
    
    /*
     * WeaponEffect for Tractio
     * Attaches effect to game object and if the "other" effect is not null starts both AttractEffect(AttachedEffect) and sets the "other" reference to null
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        if (other != null && other.gameObject == hit.gameObject)
            return;
        
        AttractEffect thisObject = hit.AddComponent<AttractEffect>();
        
        thisObject.attachEffect(other, hitPoint, other == null?primaryOnHitEffect:secondaryOnHitEffect, force, effectLifeTime);

        if (other != null)
        {
            other.attachEffect(thisObject, force, effectLifeTime);
            other = null;
        }
        else
        {
            other = thisObject;
        }
    }
}
