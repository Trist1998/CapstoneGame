using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : AbstractProjectileWeaponEffect
{
    public static readonly string SPELL_NAME = "Fyro";

    public float damage;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        HealthControl healthControl = hit.GetComponent<HealthControl>();
        if (healthControl != null)
            healthControl.takeDamage(damage);//TODO ignite object(applies continuous damage) if in fuel state and no damage if in wet state
        playPrimaryOnHitEffect(hit, hitPoint);
    }
}
