using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractProjectileWeaponEffect : AbstractWeaponEffect
{
    public float force;
    public float lifeTime;
    public Projectile projectilePrefab;
    public bool throwableWeapon;
    public override void primaryFire(Item item)
    {
        Projectile projectile = getProjectile();
        if (projectile == null) return;
        projectile.setShooter(item);
        projectile.setWeaponEffect(this);
        projectile.fire(item.player.getPlayerCameraPosition(), item.player.getPlayerCameraDirection(), force, lifeTime);
    }

    protected virtual Projectile getProjectile()
    {
        return throwableWeapon?GetComponent<Projectile>():Instantiate(projectilePrefab);
    }
}
