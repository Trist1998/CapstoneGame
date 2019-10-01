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

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        CombustioEffect effect = hit.transform.root.gameObject.AddComponent<CombustioEffect>();
        effect.startEffect(flames, burnTime, damagePerSecond, lifeTime);
        Collider[] objects = Physics.OverlapSphere(hitPoint, radius);
        foreach (var colliderObject in objects)
        {
            if (colliderObject.gameObject.GetComponent<Rigidbody>() == null) break;
            CombustioEffect c = colliderObject.gameObject.AddComponent<CombustioEffect>();
            c.startEffect(flames, burnTime, damagePerSecond, lifeTime);
            print("Attached Combustio");
        }
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
