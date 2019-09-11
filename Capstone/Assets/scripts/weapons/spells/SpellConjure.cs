using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellConjure : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Conjurio (The Conjuration Charm)";

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
