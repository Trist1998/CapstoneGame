﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellShield : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Reyouio";

    public override void fire(ObjectPickup shooter)
    {
        throw new System.NotImplementedException();
    }

    public override void processEffect(GameObject toAffect)
    {
        throw new System.NotImplementedException();
    }

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
