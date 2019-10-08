using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleWeaponEffect : AbstractWeaponEffect
{
    public Projectile whalePrefab;
    public float blastRadius;
    public float force;
    public float damage;
    
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Projectile projectile = Instantiate(whalePrefab, (hitPoint + new Vector3(0, 15, 0)), new Quaternion());
        projectile.setEffectValues(item, this);
        projectile.setPrimaryEffect(false);
    }

    public override void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                AICharacter c = colliderObject.GetComponent<AICharacter>();
                Vector3 displacement = colliderObject.transform.position - hitPoint;
                if (c != null)
                {
                    c.gameObject.AddComponent<RagdollEffect>().startEffect(1.5f);
                    
                    c.takeDamage(0.5f * damage * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1));
                }
                rigid.AddForce(force * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1) * displacement.normalized);

            }
        }
        base.processSecondaryHit(item, hit, hitPoint, direction);

    }
}
