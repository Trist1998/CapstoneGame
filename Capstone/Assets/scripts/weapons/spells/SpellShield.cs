﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShield : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Reyouio (The Shielding Charm)";

    public override void primaryFire(Item item)
    {
        throw new System.NotImplementedException();
    }

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
