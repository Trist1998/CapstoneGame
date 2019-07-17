using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDestroy : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Destructio";
    private readonly string PROJECTILE_PATH = "prefabs/weapons/wands/destructio/projectile";

    public float damage;
    public float timeout;
    public float force;

    public override void primaryFire(Item item)
    {
        GameObject projectileGameobject = Instantiate(Resources.Load(PROJECTILE_PATH)) as GameObject;
        Projectile projectile = projectileGameobject.GetComponent<Projectile>();
        
        projectile.setShooter(item);
        projectile.setWeaponEffect(this);
        projectile.GetComponent<Projectile>().fire(item.player.cam.transform.position, item.player.cam.transform.forward, force, timeout);
    }

    public override void processHit(Item item, GameObject hit, Vector3 force)
    {
        Health health = hit.GetComponent<Health>();
        if (health != null)
            health.takeDamage(damage);
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(force);

    }
   
}
