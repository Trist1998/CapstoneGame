using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLift : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Asensio";

    private LiftObjectEffect attached;
    public override void processHit(Item item, GameObject hit, Vector3 direction)
    {
        attached = hit.AddComponent(typeof(LiftObjectEffect)) as LiftObjectEffect;
        attached.attachEffect(item);
    }

    public override void primaryFire(Item item)
    {
        if (attached != null)
            attached.endEffect();
        else
            base.primaryFire(item);
    }
}
