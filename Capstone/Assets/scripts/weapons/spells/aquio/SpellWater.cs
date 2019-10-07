using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellWater : AbstractProjectileWeaponEffect
{
    public readonly string SPELL_NAME = "Aquio (The Holy Water Potion)";
    public float radius;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        
        Collider[] objects = Physics.OverlapSphere(hitPoint, radius, LayerMask.GetMask("Destructable"));
        foreach (var colliderObject in objects)
        {
            if (colliderObject.gameObject.GetComponent<WetEffect>() != null) break;
            WetEffect effect = colliderObject.gameObject.AddComponent<WetEffect>();
            effect.startEffect(lifeTime);
        }
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
