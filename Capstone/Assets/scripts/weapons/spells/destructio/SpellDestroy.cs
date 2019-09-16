using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDestroy : AbstractProjectileWeaponEffect
{
    public readonly string SPELL_NAME = "Destructio (The Destruction Charm)";

    public float damage;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 force)
    {
        WorldObject health = hit.GetComponent<WorldObject>();
        if (health != null)
            health.takeDamage(damage);
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(force);
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
