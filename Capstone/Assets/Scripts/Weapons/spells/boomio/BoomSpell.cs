using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSpell : AbstractProjectileWeaponEffect
{
    public float damage;
    public float blastRadius;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WorldObject health = hit.GetComponent<WorldObject>();
        if (health != null)
            health.takeDamage(damage);
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(speed * direction);
        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid == null) continue;
            WorldObject obj = colliderObject.GetComponent<WorldObject>();

            if (obj == null) continue;

            Vector3 displacement = colliderObject.transform.position - hitPoint;
            rigid.AddForce(
                speed * Mathf.Clamp(1 - displacement.magnitude / blastRadius, 0, 1) * displacement.normalized, ForceMode.VelocityChange);
            obj.takeDamage(0.5f * damage * Mathf.Clamp(1 - displacement.magnitude / blastRadius, 0, 1));
        }
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }

    public override string getName()
    {
        return "Boomio (Makes boom!)";
    }
}
