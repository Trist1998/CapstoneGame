using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftObjectEffect : AttachedObjectEffect
{
    Item item;
    public float speed = 2f;
    public float MaxSpeed = 5;
    public float distance = 0;
    public float maxDist = 0.05f;
    Quaternion rot;

    public override void affectObject()
    {
        InteractControl player = item.player;
        transform.rotation = rot;  
        Vector3 flyTo = player.cam.transform.position + player.cam.transform.forward * distance;
        Vector3 heading = flyTo - transform.position;
        float dist = Vector3.Distance(transform.position, flyTo);
        if (Input.GetAxis("Push") == 1 && Input.GetAxis("Fire1") == 1)
        {
            distance += 0.05f;
        }
        if (Input.GetAxis("Push") == 1 && Input.GetAxis("Fire2") == 1)
        {
            distance -= 0.05f;
        }
        Vector3 dir = heading / dist;
        if (dist > 0.05f)
        {
            if (dist > maxDist)
            {
                dist = 1;
            }
            GetComponent<Rigidbody>().velocity = dir * speed * dist;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = dir * 0;
        }
    }

    public void attachEffect(Item item)
    {
        
        this.item = item;
        lev((transform.position - item.transform.position).magnitude);     
    }

    public override void checkState()
    {
        if (!item.isEquipped())
        {
            endEffect();
        }
            
    }

    public override void endEffect()
    {
        GetComponent<Rigidbody>().useGravity = true;
        Destroy(this);
    }

    public void lev(float dist)
    {
        GetComponent<Rigidbody>().useGravity = false;
        rot = transform.localRotation;
        distance = dist;
    }

}
