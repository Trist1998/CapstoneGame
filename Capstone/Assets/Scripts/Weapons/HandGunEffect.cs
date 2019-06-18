using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunEffect : MonoBehaviour, IWeaponEffect
{
    public float damage;
    public float force;
    public GameObject bullethole;

    public void processHit(GameObject shooter, RaycastHit hit)
    {
        Health health = hit.collider.gameObject.GetComponent<Health>();
        if (health != null)
        {
            print("Hit");
            ObjectPickup pickup = shooter.GetComponent<ObjectPickup>();
            if(pickup != null)
                health.takeDamage(damage, pickup.player.cam.transform.forward.normalized, force);
        }
    }
}
