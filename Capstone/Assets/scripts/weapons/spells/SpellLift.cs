using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLift : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Asensio";

    public override void processHit(Item item, GameObject hit, Vector3 direction)
    {
        LiftObjectEffect attached = hit.AddComponent(typeof(LiftObjectEffect)) as LiftObjectEffect;
        attached.attachEffect(item);
    }
}
