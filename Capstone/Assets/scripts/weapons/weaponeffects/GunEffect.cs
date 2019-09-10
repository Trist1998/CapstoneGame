using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect : AbstractWeaponEffect
{
    public float damage;
    public float force;
    public float range;
    public GameObject bullethole;//TODO use bullethole

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WorldObject health = hit.GetComponent<WorldObject>();
        if (health != null)
        {
            health.takeDamage(damage, item.user.getItemAimDirection().normalized, force);
        }
    }

    public override float getRange()
    {
        return range;
    }

}
