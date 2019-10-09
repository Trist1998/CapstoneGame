using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCombustio : AbstractProjectileWeaponEffect
{
    public readonly string SPELL_NAME = "Combustio (The Combustion Charm)";
    public float radius;
    public ParticleSystem flames;
    public float burnTime;
    public float damagePerSecond;

    /*
     * Weapon effect for Combustio
     * Attaches CombustioEffect to objects in radius of hitPoint
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Collider[] objects = Physics.OverlapSphere(hitPoint, radius, LayerMask.GetMask("Destructable"));
        foreach (var colliderObject in objects)
        {
            if (colliderObject.gameObject.GetComponent<CombustioEffect>() != null) break;
            CombustioEffect c = colliderObject.gameObject.AddComponent<CombustioEffect>();
            c.startEffect(flames, burnTime, damagePerSecond, lifeTime);
        }
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }
}
