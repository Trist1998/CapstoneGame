using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : AbstractProjectileWeaponEffect
{
    public float damagePerSecond;
    public float baseDamage;
    public float fireTime;
    
    public float blastRadius;
    public float blastDamage;
    public float blastFireTime;
    
    /*
     * Weapon effect for Fyro
     * Attaches IgniteEffect to the hit object
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        addComboPoints(1);
        IgniteEffect ignite = hit.AddComponent<IgniteEffect>();
        ignite.startEffect(secondaryOnHitEffect, baseDamage, damagePerSecond, fireTime);
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }

    public override void secondaryFire(Item item)
    {
        Projectile projectile = getProjectile();
        if (projectile == null) return;
        projectile.transform.localScale = Vector3.one * 2;
        projectile.setEffectValues(item, this);
        projectile.setPrimaryEffect(false);
        projectile.fire(item.user.getItemAimPosition(), item.user.getItemAimDirection(), useGravity, speed, lifeTime);
    }
    
    public override void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius, LayerMask.GetMask("Destructable"));
        foreach (var colliderObject in objects)
        {
            IgniteEffect ignite = colliderObject.gameObject.AddComponent<IgniteEffect>();
                ignite.startEffect(secondaryOnHitEffect, blastDamage, damagePerSecond, blastFireTime);
        }
        
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }
    
    
}
