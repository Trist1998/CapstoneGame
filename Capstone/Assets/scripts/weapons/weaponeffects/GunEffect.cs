using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect : AbstractWeaponEffect
{
    public float damage;
    public float force;
    public float range;
    public GameObject bullethole;

    public override void processHit(Item item, GameObject hit, Vector3 direction)
    {
        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.takeDamage(damage, item.player.cam.transform.forward.normalized, force);
        }
    }

    public override float getRange()
    {
        return range;
    }

}
