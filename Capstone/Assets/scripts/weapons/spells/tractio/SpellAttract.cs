using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttract : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Tractio";
    
    private AttractObjectEffect otherObject;
    public float effectLifeTime;
    public float force;
    
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)//This is gross logic
    {
        if (otherObject != null && otherObject.gameObject == hit.gameObject)
            return;
        
        AttractObjectEffect thisObject = hit.AddComponent<AttractObjectEffect>();
        
        thisObject.attachEffect(otherObject, hitPoint, force, effectLifeTime);

        if (otherObject != null)
        {
            otherObject.attachEffect(thisObject, force, effectLifeTime);
            otherObject = null;
        }
        else
        {
            otherObject = thisObject;
        }
    }
}
