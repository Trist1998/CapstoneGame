﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellConjure : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Conjurio";

    public override void fire(ObjectPickup shooter)
    {
        throw new System.NotImplementedException();
    }

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
