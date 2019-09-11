using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttract : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Tractio (The Attraction Charm)";
    
    private AttractEffect other;
    public float effectLifeTime;
    public float force;
    
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)//This is gross logic
    {
        if (other != null && other.gameObject == hit.gameObject)
            return;
        
        AttractEffect @this = hit.AddComponent<AttractEffect>();
        
        @this.attachEffect(other, hitPoint, other == null?primaryOnHitEffect:secondaryOnHitEffect, force, effectLifeTime);

        if (other != null)
        {
            other.attachEffect(@this, force, effectLifeTime);
            other = null;
        }
        else
        {
            other = @this;
        }
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
