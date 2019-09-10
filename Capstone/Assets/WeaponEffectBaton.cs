using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffectBaton : AbstractWeaponEffect
{
    public float damage;
    public float range;
    public float force;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WorldObject health = hit.transform.root.GetComponent<WorldObject>();
        if(health != null)
            health.takeDamage(damage,direction, force);
        base.processPrimaryHit(item, hit, hitPoint, direction);
        Item.print("Hit");
    }

    public override float getRange()
    {
        return range;
    }
}
