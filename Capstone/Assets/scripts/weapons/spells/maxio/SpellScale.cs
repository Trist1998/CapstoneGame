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
        InflateEffect hitObject = hit.transform.root.GetComponent<InflateEffect>();
        if (hitObject != null)
        {
            hitObject.repeatHit();
        }
        else if(hit.transform.root.GetComponent<IWorldObject>() != null)
        {
            hitObject = hit.transform.root.gameObject.AddComponent<InflateEffect>();
            hitObject.startEffect();
        }
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
