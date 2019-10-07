using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustioEffect : AttachedEffect
{
    private ParticleSystem flames;
    private float burnTime;
    private float damagePerSecond;
    public bool combusted;
    
    
    public void startEffect(ParticleSystem flamesParticles, float burnTime, float damagePerSecond, float lifetime)
    {
        flames = flamesParticles;
        this.burnTime = burnTime;
        this.damagePerSecond = damagePerSecond;
        negatingStates[AttachedEffectManager.STATE_WET] = 5;
        appliedStates[AttachedEffectManager.STATE_IGNITABLE] = 5;
        base.startEffect(lifetime);
    }

    protected void combust()
    {
        if (combusted) return;
        combusted = true;
        GetComponent<IgniteEffect>()?.endEffect();
        IgniteEffect newEffect = gameObject.AddComponent<IgniteEffect>();
        newEffect.startEffect(flames,10, damagePerSecond, burnTime);
        
        Collider[] objects = Physics.OverlapSphere(transform.position, 7.5f, LayerMask.GetMask("Destructable"));
        foreach (var colliderObject in objects)
        {
            CombustioEffect combustio = colliderObject.GetComponent<CombustioEffect>();
            if(combustio != null)
                colliderObject.GetComponent<CombustioEffect>().combust();
        }
    }
    public override void affectObject()
    {
        AttachedEffectManager manager = getManager();
        if (manager == null || !manager.hasState(AttachedEffectManager.STATE_IGNITION)) return;
        combust();
        endEffect();
    }

    public override void endEffect(string reason)
    {
        if(reason == AttachedEffectManager.STATE_IGNITION)
            combust();
        base.endEffect(reason);
    }
}
