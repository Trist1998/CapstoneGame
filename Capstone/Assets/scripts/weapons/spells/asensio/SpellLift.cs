using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLift : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Asensio";

    public float shootForwardForce;

    private LiftEffect attached;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        attached = hit.AddComponent(typeof(LiftEffect)) as LiftEffect;
        attached.startEffect(item);
    }

    public override void primaryFire(Item item)
    {
        if (attached != null)
            attached.endEffect();
        else
            base.primaryFire(item);
    }

    public override void secondaryFire(Item item)
    {
        if(attached != null)
            attached.shootForward(shootForwardForce);
    }
}
