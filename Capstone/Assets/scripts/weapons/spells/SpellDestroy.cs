using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellDestroy : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Destructio";
    private readonly string PROJECTILE_PATH = "prefabs/weapons/wands/destructio/projectile";

    public float damage;
    public float timeout;
    public float force;

    public override void fire(ObjectPickup shooter)
    {
        GameObject projectileGameobject = Instantiate(Resources.Load(PROJECTILE_PATH)) as GameObject;
        Projectile projectile = projectileGameobject.GetComponent<Projectile>();
        
        projectile.setShooter(shooter);
        projectile.setWeaponEffect(this);
        projectile.GetComponent<Projectile>().fire(shooter.player.transform.position, shooter.player.cam.transform.forward, force, timeout);
    }

    public override void processEffect(GameObject toAffect)
    {
        Health health = toAffect.GetComponent<Health>();
        if (health != null)
            health.takeDamage(damage);
    }

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 force)
    {
        processEffect(hit);
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(force);
    }
   
}
