using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDestroy : AbstractProjectileWeaponEffect
{
    public float blastRadius;
    public float damage;
    public float blastForce;
    /*
     * Weapon effect for Destructio
     * Applies force and damage to objects in blast radius
     * Damage decreases as distance from blast increases
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 force)
    {
        WorldObject health = hit.GetComponent<WorldObject>();
        if (health != null)
            health.takeDamage(damage);
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(force, ForceMode.VelocityChange);
        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid == null) continue;
            WorldObject obj = colliderObject.GetComponent<WorldObject>();
            
            if (obj == null) continue;
            
            Vector3 displacement = colliderObject.transform.position - hitPoint;
            rigid.AddForce(blastForce * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1) * displacement.normalized);
            obj.takeDamage(0.5f * damage * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1));
        }
        base.processPrimaryHit(item, hit, hitPoint, force);
    }

}
