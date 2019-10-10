using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffectBaton : AbstractWeaponEffect
{
    public float damage;
    public float range;
    public float force;
    /*
     * Basic weapon effect applies damage at hit
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WorldObject health = hit.transform.GetComponent<WorldObject>();
        if(health != null)
            health.takeDamage(damage,direction, force);
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }

    public override float getRange()
    {
        return range;
    }
}
