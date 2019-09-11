using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWater : AbstractProjectileWeaponEffect
{
    public readonly string SPELL_NAME = "Aquio (The Holy Water Potion)";

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WetEffect effect = hit.AddComponent<WetEffect>();
        effect.startEffect(lifeTime);
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
