using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellLift : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Asensio";

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
