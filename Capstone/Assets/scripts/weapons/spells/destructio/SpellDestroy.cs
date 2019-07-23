using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDestroy : AbstractProjectileWeaponEffect
{
    public readonly string SPELL_NAME = "Destructio";

    public float damage;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 force)
    {
        HealthControl healthControl = hit.GetComponent<HealthControl>();
        if (healthControl != null)
            healthControl.takeDamage(damage);
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(force);
        playPrimaryOnHitEffect(hit, hitPoint);
    }
   
}
