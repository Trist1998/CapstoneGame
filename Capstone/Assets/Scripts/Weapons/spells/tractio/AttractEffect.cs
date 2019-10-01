using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractEffect : AttachedEffect
{
    [SerializeField]
    private AttractEffect attractTo;
    [SerializeField]
    private Vector3 attractionPoint;
    private float force;
    private bool hasAttached;
    private ParticleSystem particles;
    private Rigidbody rig;
    

    public void attachEffect(AttractEffect attractTo, float force, float lifeTime)
    {
        rig = getRigidBody();
        
        if (rig != null)
            this.attractTo = attractTo;
        
        this.force = force;
        
        startEffect(lifeTime);
        ragdoll();
    }
    
    public void attachEffect(AttractEffect attractTo, Vector3 pointOfAttraction, ParticleSystem effect, float force, float lifeTime)
    {
        particles = Instantiate(effect, gameObject.transform);
        particles.transform.position = pointOfAttraction;
        particles.Play();
        attractionPoint = pointOfAttraction;
        attachEffect(attractTo, force, lifeTime);
        ragdoll();
    }

    private void ragdoll()
    {
        if(isNPC())
            GetComponent<AICharacter>().ragdoll();
    }
    
    private void unragdoll()
    {
        if(isNPC())
            GetComponent<AICharacter>().unragdoll();
    }

    private bool isNPC()
    {
        return GetComponent<AICharacter>() != null;
    }

    private Rigidbody getRigidBody()
    {
        if(isMovableObject())
            return isNPC() ? GetComponent<AICharacter>().childBody : GetComponent<Rigidbody>();
        return null;
    }
    
    public override void affectObject()
    {
        if (attractTo != null)
        {
            rig.AddForce(getForce() * getForceDirection(), ForceMode.VelocityChange);
        }
    }

    public Vector3 getPosition()
    {
        return !isMovableObject() ? attractionPoint : rig.position;
    }
    
    public float getForce()
    {
        return force;// * (Mathf.Max(rig.mass, 1) * Mathf.Max(attractTo.GetComponent<Rigidbody>().mass, 1))/Mathf.Max(Mathf.Pow((attractTo.getPosition() - transform.position).magnitude, 2), 5);
    }
    
    private Vector3 getForceDirection()
    {
        return (attractTo.getPosition() - getPosition()).normalized;
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
        unragdoll();
        Destroy(particles);
        base.endEffect();
    }
}
