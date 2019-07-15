using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellEnlarge : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Maxio";

    public float range;
    public float scalar;

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction)
    {
        hit.transform.localScale *= scalar;
    }

    public override float getRange()
    {
        return range;
    }

}
