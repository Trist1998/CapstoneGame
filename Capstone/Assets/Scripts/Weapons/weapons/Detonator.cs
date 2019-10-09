using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : Item
{
    
    private GenericTimer timer;
    public float blastRadius;
    public float timeDelay;
    public float force;
    public float damage;
    public ParticleSystem explosion;
    public Sound explosionSound;
    
    /*
     * Starts timer of grenade if timer is null
     * If timer done grenade explodes which applies damage and force to objects in blastRadius
     */
    public override void usePrimaryActionDown()
    {
        if (timer == null)
            timer = new GenericTimer(timeDelay, false);
        if (!timer.isTimeout()) return;
        Collider[] objects = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid == null) continue;
            WorldObject obj = colliderObject.GetComponent<WorldObject>();
            
            if (obj == null) continue;
            
            Vector3 displacement = colliderObject.transform.position - transform.position;
            rigid.AddForce(force * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1) * displacement.normalized);
            obj.takeDamage(0.5f * damage * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1));
        }
        
        ParticleSystem effect = Instantiate(explosion);
        effect.transform.position = transform.position;
        effect.Play();
        explosionSound.playSound(transform.position);
    }

    public override float getAmmoPercentage()
    {
        return 1;
    }
}
