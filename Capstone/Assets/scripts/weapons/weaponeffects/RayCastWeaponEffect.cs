using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RayCastWeaponEffect : AbstractWeaponEffect
{
    public abstract float getRange();

    public override void fire(ObjectPickup shooter)
    {
        RaycastHit hit;
        Vector3 origin = shooter.player.cam.transform.position;
        Vector3 direction = shooter.player.cam.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            processHit(shooter, hit.collider.gameObject, direction);
        }
    }
}
