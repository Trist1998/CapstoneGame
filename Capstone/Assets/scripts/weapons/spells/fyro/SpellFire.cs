using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : AbstractWeaponEffect
{
    public static readonly string SPELL_NAME = "Fyro";
    private static readonly string PROJECTILE_PATH = "prefabs/weapons/wands/fyro/projectile";
    
    public float damage;
    public float timeout;
    public float force;

    public override void primaryFire(Item item)
    {
        GameObject projectileGameObject = Instantiate(Resources.Load(PROJECTILE_PATH)) as GameObject;
        Projectile projectile = projectileGameObject?.GetComponent<Projectile>();
        
        projectile?.setShooter(item);
        projectile?.setWeaponEffect(this);
        projectile?.GetComponent<Projectile>()?.fire(item.player.getPlayerCameraPosition(), item.player.getPlayerCameraDirection(), force, timeout);
    }

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        HealthControl healthControl = hit.GetComponent<HealthControl>();
        if (healthControl != null)
            healthControl.takeDamage(damage);//TODO ignite object(applies continuous damage) if in fuel state and no damage if in wet state
    }
}
