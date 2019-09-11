using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScale : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Maxio (The Scaling Charm)";

    public float range;
    public float scalar;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        IWorldObject hitObject = hit.GetComponent<IWorldObject>();
        if(hitObject != null)
            hit.transform.localScale *= scalar;
    }
    
    public override void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        IWorldObject hitObject = hit.GetComponent<IWorldObject>();
        if(hitObject != null)
            hit.transform.localScale *= 1/scalar;
    }

    public override float getRange()
    {
        return range;
    }

    public override string getName()
    {
        return SPELL_NAME;
    }

}
