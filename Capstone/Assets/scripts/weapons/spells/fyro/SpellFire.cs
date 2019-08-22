using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : AbstractProjectileWeaponEffect
{
    public static readonly string SPELL_NAME = "Fyro";

    public float damage;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        IgniteEffect ignite = hit.AddComponent<IgniteEffect>();//TODO ignite object(applies continuous damage) if in fuel state and no damage if in wet state
        ignite.startEffect(secondaryOnHitEffect, damage, lifeTime);
        playPrimaryOnHitEffect(hit, hitPoint);
    }
}
