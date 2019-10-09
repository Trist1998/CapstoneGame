using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProjectileWeaponEffect : AbstractWeaponEffect
{
    public float speed;
    public float lifeTime;
    public Projectile projectilePrefab;
    public bool useGravity;
    
    /*
     * Overrides primary fire to file projectile instead
     */
    public override void primaryFire(Item item)
    {
        Projectile projectile = getProjectile();
        if (projectile == null) return;
        projectile.setEffectValues(item, this);
            projectile.fire(item.user.getItemAimPosition(), item.user.getItemAimDirection(), useGravity, speed, lifeTime);
            
    }

    /*
     * Returns the projectile
     */
    protected virtual Projectile getProjectile()
    {
        return Instantiate(projectilePrefab);
    }
}
