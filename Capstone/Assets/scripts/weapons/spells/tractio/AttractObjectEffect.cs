using System.Collections;
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
    
    public void attachEffect(AttractObjectEffect attractTo, float force, float lifeTime)
    {
        if(GetComponent<Rigidbody>() != null)
            this.attractTo = attractTo;
        this.force = force;
        startEffect(lifeTime);
    }
    
    public void attachEffect(AttractObjectEffect attractTo, Vector3 pointOfAttraction, ParticleSystem effect, float force, float lifeTime)
    {
        particles = Instantiate(effect, gameObject.transform);
        particles.transform.position = pointOfAttraction;
        particles.Play();
        this.attractionPoint = pointOfAttraction;
        attachEffect(attractTo, force, lifeTime);
    }
    
    public override void affectObject()
    {
        if (attractTo != null)
        {
            GetComponent<Rigidbody>().AddForce(getForceDirection() * force);
        }
    }
    
    public Vector3 getPosition()
    {
        if(!isMovableObject())
            return attractionPoint;
        return transform.position;
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
