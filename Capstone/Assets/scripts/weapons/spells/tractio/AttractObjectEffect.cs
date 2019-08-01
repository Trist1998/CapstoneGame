﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractObjectEffect : AttachedObjectEffect
{
    [SerializeField]
    private AttractObjectEffect attractTo;
    [SerializeField]
    private Vector3 attractionPoint;
    private float force;
    private bool hasAttached;
    private ParticleSystem particles;
    private Rigidbody rig;
    
    public void attachEffect(AttractObjectEffect attractTo, float force, float lifeTime)
    {
        rig = GetComponent<Rigidbody>();
        if (rig != null)
        {
            this.attractTo = attractTo;
            
            if(attractTo != null)
                rig.AddForce(force * getForceDirection());
        }

        
            
        this.force = force;
        
        startEffect(lifeTime);
    }
    
    public void attachEffect(AttractObjectEffect attractTo, Vector3 pointOfAttraction, ParticleSystem effect, float force, float lifeTime)
    {
        particles = Instantiate(effect, gameObject.transform);
        particles.transform.position = pointOfAttraction;
        particles.Play();
        attractionPoint = pointOfAttraction;
        attachEffect(attractTo, force, lifeTime);
    }
    
    public override void affectObject()
    {
        if (attractTo != null)
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.AddForce(getForce() * getForceDirection());
        }
    }

    public Vector3 getPosition()
    {
        if(!isMovableObject())
            return attractionPoint;
        return transform.position;
    }
    
    public float getForce()
    {
        Rigidbody rig = GetComponent<Rigidbody>();
        return force * (Mathf.Max(rig.mass, 1) * Mathf.Max(attractTo.GetComponent<Rigidbody>().mass, 1))/Mathf.Max(Mathf.Pow((attractTo.getPosition() - transform.position).magnitude, 2), 5);
    }
    
    private Vector3 getForceDirection()
    {
        return (attractTo.getPosition() - transform.position).normalized;
    }

    void OnCollisionEnter(Collision other)
    {
        if(attractTo == null || other.gameObject == attractTo.gameObject)
        {
            //endEffect();
        }
    }

    public override void endEffect()
    {
        if(particles != null) particles.Stop();
        Destroy(particles);
        base.endEffect();
    }
}
