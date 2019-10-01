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
        rigid.transform.rotation = rot;  
        Vector3 flyTo = player.getItemAimPosition() + player.getItemAimDirection() * distance;
        Vector3 heading = flyTo - getPosition();
        //float dist = Vector3.Distance(getPosition(), flyTo);
        Vector3 force = heading / Time.fixedDeltaTime * 0.03f;
        rigid.velocity = Vector3.zero;
        rigid.AddForce(force, ForceMode.VelocityChange);
    }

    public Vector3 getPosition()
    {
        return rigid.transform.position;
    }

    public Rigidbody getRigidbody()
    {
        AICharacter c = transform.root.GetComponent<AICharacter>();
        return c != null ? c.childBody : GetComponent<Rigidbody>();
    }

    public void startEffect(Item item)
    {
        this.item = item;
        
        rigid = getRigidbody();
        if (!isMovableObject())
        {
            Destroy(this);
            return;
        }

        
        levitate((rigid.transform.position - item.user.getItemAimPosition()).magnitude);     
    }

    public override void endEffect()
    {
        if (GetComponent<AICharacter>() != null)
        {
            gameObject.AddComponent<RagdollEffect>().startEffect(1);
            rigid.isKinematic = false;
        }
        rigid.useGravity = true;
        
        Destroy(this);
    }

    public void shootForward(float force)
    {
        rigid.velocity = Vector3.zero;
        rigid.AddForce(item.user.getItemAimDirection() * force, ForceMode.VelocityChange);
        rigid.isKinematic = false;
        rigid.useGravity = true;
        shotForward = true;
    }

    private void levitate(float dist)
    {
        if (GetComponent<AICharacter>() != null)
        {
            GetComponent<AICharacter>().ragdoll();
        }
        rigid.useGravity = false;
        rot = rigid.transform.localRotation;
        distance = dist;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (!shotForward) return;
        if(getLifeTimer() == null)
            setLifeTimer(new GenericTimer(1, false));
        if (other.transform.root == transform.root) return;

        AICharacter c = other.gameObject.GetComponent<AICharacter>();
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        if (c != null)
        {
            r = c.childBody;
            c.takeDamage(50);
            c.gameObject.AddComponent<RagdollEffect>().startEffect(1);
        }
        if (r != null)
        {
            r.AddForce(other.impulse);
        }
            
        

    }
}
