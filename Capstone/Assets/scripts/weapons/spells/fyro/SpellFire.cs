using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : AbstractProjectileWeaponEffect
{
    public float damagePerSecond;
    public float baseDamage;

    /*
     * Weapon effect for Fyro
     * Attaches IgniteEffect to the hit object
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        IgniteEffect ignite = hit.AddComponent<IgniteEffect>();
        ignite.startEffect(secondaryOnHitEffect, baseDamage, damagePerSecond, lifeTime);
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }
    
}
