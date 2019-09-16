using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellElectric : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Paratacio (The Electric Charm)";
    public float damagePerSecond;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        hit.GetComponent<WorldObject>()?.takeDamage(damagePerSecond * Time.deltaTime);//TODO more damage if wet state and damage nearby wet objects
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }

}
