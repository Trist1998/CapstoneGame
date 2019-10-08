using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScale : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Maxio (The Scaling Charm)";

    public float range;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        InflateEffect hitObject = hit.transform.root.GetComponent<InflateEffect>();
        if (hitObject != null)
        {
            hitObject.repeatHit();
            base.processPrimaryHit(item, hit, hitPoint, direction);
        }
        else if(hit.transform.root.GetComponent<IWorldObject>() != null)
        {
            hitObject = hit.transform.root.gameObject.AddComponent<InflateEffect>();
            hitObject.startEffect();
            base.processPrimaryHit(item, hit, hitPoint, direction);
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
