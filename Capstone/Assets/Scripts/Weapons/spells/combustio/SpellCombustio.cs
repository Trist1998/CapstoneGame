using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCombustio : AbstractProjectileWeaponEffect
{
    public readonly string SPELL_NAME = "Combustio (The Combustion Charm)";

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        CombustioEffect effect = hit.AddComponent<CombustioEffect>();
        effect.startEffect(lifeTime);
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
