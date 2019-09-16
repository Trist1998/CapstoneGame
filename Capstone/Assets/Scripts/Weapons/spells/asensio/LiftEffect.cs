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

    public override void affectObject()
    {
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
        float velo = (dist * dist) + dist;
        Vector3 dir = heading / dist;
        if (dist > 0.05f)
        {
            if (dist > maxDist)
            {
                dist = 1;
            }
            transform.position += Time.deltaTime * velo * heading;
        }
    }

    public void startEffect(Item item)
    {
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
        endEffect();
    }

    public void lev(float dist)
    {
        GetComponent<Rigidbody>().useGravity = false;
        rot = transform.localRotation;
        distance = dist;
    }

}
