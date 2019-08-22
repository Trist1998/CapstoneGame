using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustioEffect : AttachedEffect
{
    public override void affectObject()
    {
        IgniteEffect ignite = gameObject.GetComponent<IgniteEffect>();
        if (ignite == null) return;
        ignite.getLifeTimer().setLifeTime(10);
        gameObject.GetComponent<HealthControl>().takeDamage(25);
        endEffect();
    }

}
