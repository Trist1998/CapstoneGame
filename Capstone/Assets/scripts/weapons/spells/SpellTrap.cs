using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTrap : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Trapio";

    public override void primaryFire(Item item)
    {
        throw new System.NotImplementedException();
    }

    public override void processHit(Item item, GameObject hit, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
