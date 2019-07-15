using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunEffect : AbstractWeaponEffect
{
    public float damage;
    public float force;
    public float range;
    public GameObject bullethole;

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction)
    {
        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            ObjectPickup pickup = shooter.GetComponent<ObjectPickup>();
            if(pickup != null)
                health.takeDamage(damage, pickup.player.cam.transform.forward.normalized, force);
        }
    }

    public override float getRange()
    {
        return range;
    }

    public override void processEffect(GameObject toAffect)
    {
        throw new System.NotImplementedException();
    }
}
