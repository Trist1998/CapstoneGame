using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpell : AbstractProjectileWeaponEffect
{
    public int addHitPoints;
    public float duration;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, 4.5f);
        foreach (var colliderObject in objects)
        {
            WorldObject wO = hit.GetComponent<WorldObject>();
            if (wO != null)
            {
                HealthEffect effect = colliderObject.gameObject.AddComponent<HealthEffect>();
                effect.startEffect(wO, addHitPoints, duration);
            }
            
        }
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }
    
    public override string getName()
    {
        return "Healio (Soothes the pain)";
    }
}
