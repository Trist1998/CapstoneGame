using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellElectric : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Paratacio";
    public float damagePerSecond;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        hit.GetComponent<HealthControl>()?.takeDamage(damagePerSecond * Time.deltaTime);//TODO more damage if wet state and damage nearby wet objects
        playPrimaryOnHitEffect(hit, hitPoint);
    }
}
