using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftEffect : AttachedEffect
{
    Item item;
    public float speed = 6f;
    public float maxSpeed = 5;
    public float distance = 0;
    public float maxDist = 0.05f;
    Quaternion rot;
    private bool shotForward = false;
    private Rigidbody rigid;

    public override void affectObject()
    {
        if (shotForward) return;
        if (!item.isEquipped())
        {
            endEffect();
            return;
        }
        IItemUser player = item.user;
        transform.rotation = rot;  
        Vector3 flyTo = player.getItemAimPosition() + player.getItemAimDirection() * distance;
        Vector3 heading = flyTo - transform.position;
        float dist = Vector3.Distance(transform.position, flyTo);
        Vector3 force = heading / Time.fixedDeltaTime * 0.03f;
        rigid.velocity = Vector3.zero;
        rigid.AddForce(force, ForceMode.VelocityChange);
    }

    public void startEffect(Item item)
    {
        AICharacter c = GetComponent<AICharacter>();
        rigid = c != null ? c.childBody : GetComponent<Rigidbody>();
        
        if (!isMovableObject())
        {
            Destroy(this);
            return;
        }

        if (GetComponent<AICharacter>() != null)
        {
            GetComponent<AICharacter>().ragdoll();
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        
           
        
        this.item = item;
        lev((transform.position - item.user.getItemAimPosition()).magnitude);     
    }

    public override void endEffect()
    {
        if (GetComponent<AICharacter>() != null)
        {
            GetComponent<AICharacter>().unragdoll();
            GetComponent<Rigidbody>().isKinematic = false;
        }
        GetComponent<Rigidbody>().useGravity = true;
        
        Destroy(this);
    }

    public void shootForward(float force)
    {
        GetComponent<Rigidbody>().AddForce(item.user.getItemAimDirection() * force);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        shotForward = true;
    }

    public void lev(float dist)
    {
        GetComponent<Rigidbody>().useGravity = false;
        rot = transform.localRotation;
        distance = dist;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (!shotForward) return;
        shotForward = false;
        AICharacter c = other.gameObject.GetComponent<AICharacter>();
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        if (r != null)
        {
            r.AddForce(other.impulse);
        }
            
        if (c != null)
        {
            c.takeDamage(50);
            c.gameObject.AddComponent<RagdollEffect>().startEffect(1);
        }
            
            
        endEffect();

    }
}
