using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustioEffect : AttachedEffect
{
    private ParticleSystem flames;
    private float burnTime;
    private float damagePerSecond;
    
    public void startEffect(ParticleSystem flamesParticles, float burnTime, float damagePerSecond, float lifetime)
    {
        flames = flamesParticles;
        this.burnTime = burnTime;
        this.damagePerSecond = damagePerSecond;
        base.startEffect(lifetime);
    }
    
    public override void affectObject()
    {
        AttachedEffectManager manager = transform.root.GetComponent<AttachedEffectManager>();
        if (manager != null && manager.hasState(AttachedEffectManager.STATE_FIRE))
        {
            GetComponent<IgniteEffect>().endEffect();
            IgniteEffect newEffect = gameObject.AddComponent<IgniteEffect>();
            newEffect.startEffect(flames,10, damagePerSecond, burnTime);
        }

        Collider[] objects = Physics.OverlapSphere(transform.position, 5);
        foreach (var colliderObject in objects)
        {
            manager = colliderObject.transform.root.GetComponent<AttachedEffectManager>();
            if (manager == null) return;
            if (!manager.hasState(AttachedEffectManager.STATE_FIRE)) break;
            if (manager.GetComponent<IgniteEffect>()?.damagePerSecond == damagePerSecond) break;
            manager.GetComponent<IgniteEffect>()?.endEffect();
            IgniteEffect newEffect = manager.gameObject.AddComponent<IgniteEffect>();
            newEffect.startEffect(flames, 10, damagePerSecond, burnTime);
        }
        endEffect();
    }

}
