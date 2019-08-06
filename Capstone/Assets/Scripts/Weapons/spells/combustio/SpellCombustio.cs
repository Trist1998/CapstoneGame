using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCombustio : AbstractProjectileWeaponEffect
{
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        CombustioObjectEffect effect = hit.AddComponent<CombustioObjectEffect>();
        effect.startEffect(lifeTime);
        playPrimaryOnHitEffect(hit, hitPoint);
    }
}
