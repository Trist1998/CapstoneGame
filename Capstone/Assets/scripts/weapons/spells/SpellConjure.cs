using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellConjure : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Conjurio";

    public override void fire(Item item)
    {
        throw new System.NotImplementedException();
    }

    public override void processHit(Item item, GameObject hit, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
