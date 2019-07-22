using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProjectileWeaponEffect : AbstractWeaponEffect
{
    public float force;
    public float lifeTime;
    public Projectile projectilePrefab;
    public bool throwableWeapon;
    public bool useGravity;
    
    public override void primaryFire(Item item)
    {
        Projectile projectile = getProjectile();
        if (projectile == null) return;
            if (throwableWeapon) 
            {
                item.transform.parent = null;//TODO maybe make this use grenade prefab instead of throwing item
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            projectile.setEffectValues(item, this);
            projectile.fire(item.user.getUserAimPosition(), item.user.getUserAimDirection(), useGravity, force, lifeTime);
            
    }

    protected virtual Projectile getProjectile()
    {
        return throwableWeapon?GetComponent<Projectile>():Instantiate(projectilePrefab);
    }
}
