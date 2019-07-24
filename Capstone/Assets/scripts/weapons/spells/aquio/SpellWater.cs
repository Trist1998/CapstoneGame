using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWater : AbstractProjectileWeaponEffect
{
    
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WetObjectEffect effect = hit.AddComponent<WetObjectEffect>();
        effect.startEffect(lifeTime);
        playPrimaryOnHitEffect(hit, hitPoint);
    }
    
}
