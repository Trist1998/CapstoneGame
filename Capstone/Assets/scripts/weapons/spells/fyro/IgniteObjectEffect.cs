﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteObjectEffect : AttachedObjectEffect
{
    private float damagePerSecond;
    private ParticleSystem particles;
    
    public void startEffect(ParticleSystem effect, float damagePerSecond, float lifeTime)
    {
        particles = Instantiate(effect, gameObject.transform);
        particles.transform.position = transform.position;
        particles.Play();
        this.damagePerSecond = damagePerSecond;
        appliedStates[STATE_FIRE] = 5;
        negatingStates[STATE_WET] = 5;
        base.startEffect(lifeTime);
    }

    public override void affectObject()
    {
        base.affectObject();
        GetComponent<HealthControl>()?.takeDamage(damagePerSecond * Time.deltaTime);
    }

    public override void endEffect()
    {
        particles.Stop();
        Destroy(particles);
        base.endEffect();
    }
}
