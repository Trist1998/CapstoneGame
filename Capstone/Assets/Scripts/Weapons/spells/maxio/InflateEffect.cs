using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class InflateEffect : AttachedEffect
{
    private Vector3 startingScale;
    private Vector3 scaleOnHit;
    private float timeSinceHit;
    
    public void startEffect()
    {
        startingScale = transform.localScale;
        timeSinceHit = 0;
        scaleOnHit = transform.localScale;
        base.startEffect(-1);
    }

    public override void affectObject()
    {
        timeSinceHit += Time.deltaTime;
        if(transform.localScale.x < startingScale.x)
            endEffect();
        else if (transform.localScale.x >= 3 * startingScale.x)
        {
            if(GetComponent<WorldObject>() != null)
                GetComponent<WorldObject>().takeDamage(float.MaxValue);
            endEffect("Explosion");
        }
        else
        {
            float scaleX = -2f * timeSinceHit * timeSinceHit + 2.5f * timeSinceHit + scaleOnHit.x;
            float scaleZ = -2f * timeSinceHit * timeSinceHit + 2.5f * timeSinceHit + scaleOnHit.z;
            transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ);
            base.affectObject();
        }
        
    }

    public void repeatHit()
    {
        scaleOnHit = transform.localScale;
        timeSinceHit = 0;
    }
    

    public override void endEffect()
    {
        transform.localScale = startingScale;
        base.endEffect();
    }
}
