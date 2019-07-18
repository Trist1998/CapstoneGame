using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractObjectEffect : AttachedObjectEffect
{
    private AttractObjectEffect attractTo;
    [SerializeField]
    private Vector3 attractionPoint;
    private float force;
    private bool hasAttached;
    
    public void attachEffect(AttractObjectEffect attractTo, float force, float lifeTime)
    {
        if(GetComponent<Rigidbody>() != null)
            this.attractTo = attractTo;
        this.force = force;
        attachEffect(0, lifeTime);
    }
    
    public void attachEffect(AttractObjectEffect attractTo, Vector3 pointOfAttraction, float force, float lifeTime)
    {
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
    
    protected override void checkState()
    {
        //if(attractTo == null)
            //endEffect();
    }

    void OnCollisionEnter(Collision other)
    {
        if(attractTo == null || other.gameObject == attractTo.gameObject)
        {
            endEffect();
        }
    }

    private bool isMovableObject()
    {
        return GetComponent<Rigidbody>() != null && !GetComponent<Rigidbody>().isKinematic;
    }
    
}
