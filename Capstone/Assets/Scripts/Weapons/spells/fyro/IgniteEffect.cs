using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteEffect : AttachedEffect
{
    public float damagePerSecond;
    private ParticleSystem particles;

    public void startEffect(ParticleSystem effect, float baseDamage, float damagePerSecond, float lifeTime)
    {
        particles = Instantiate(effect, gameObject.transform);
        particles.transform.position = transform.position;
        particles.Play();
        this.damagePerSecond = damagePerSecond;
        appliedStates[AttachedEffectManager.STATE_FIRE] = 5;
        appliedStates[AttachedEffectManager.STATE_IGNITION] = 5;
        negatingStates[AttachedEffectManager.STATE_WET] = 5;
        base.startEffect(lifeTime);
        if(!effectEnded)
            GetComponent<WorldObject>()?.takeDamage(baseDamage);
    }

    public override void affectObject()
    {
        base.affectObject();
        GetComponent<WorldObject>()?.takeDamage(damagePerSecond * Time.deltaTime);
    }

    public override void endEffect()
    {
        particles.Stop();
        Destroy(particles);
        base.endEffect();
    }
}
