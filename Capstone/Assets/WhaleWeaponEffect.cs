using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleWeaponEffect : AbstractWeaponEffect
{
    public Projectile whalePrefab;
    public float blastRadius;
    public float force;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Projectile projectile = Instantiate(whalePrefab, (hitPoint + new Vector3(0, 15, 0)), new Quaternion());
        projectile.setEffectValues(item, this);
        projectile.setPrimaryEffect(false);
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }

    public override void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                Vector3 displacment = colliderObject.transform.position - hitPoint;
                rigid.AddForce(force * Mathf.Clamp(1 - displacment.magnitude/blastRadius, 0, 1) * displacment.normalized);
            }
        }
        base.processSecondaryHit(item, hit, hitPoint, direction);
    }
}
