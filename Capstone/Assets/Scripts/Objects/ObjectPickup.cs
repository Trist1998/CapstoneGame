using UnityEngine;
using System.Collections;

public class ObjectPickup : MonoBehaviour, IWorldObject
{
    public bool stuck = false;
    public bool levitate = false;
    public bool equipable = false;

    public InteractControl player;
    public GameObject handBone;
    public Vector3 relPosi;
    public Vector3 relRotation;

    bool eWasUp = false;
    public float speed = 2f;
    public float MaxSpeed = 5;
    public float distance = 0;
    public float maxDist = 0.05f;
    Quaternion rot;

   
	void onHand()
    {
        if (stuck)
        {   
            transform.parent = handBone.transform;
            transform.localPosition = relPosi;
            transform.Rotate(relRotation);     
        }
    }

	// Update is called once per frame
	void Update ()
    {
        onHand();
        moveInAir();
	}

    void moveInAir()
    {
        if (levitate)
        {
            transform.rotation = rot;
            this.GetComponent<Rigidbody>().useGravity = false;
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
                this.GetComponent<Rigidbody>().velocity  = dir * speed * dist;
            }
            else
            {
                this.GetComponent<Rigidbody>().velocity = dir *0;
            }
            
            if (Input.GetButtonUp("Interact"))//Do this in InteractControl??
            {
                eWasUp = true;
            }
            if (Input.GetButtonDown("Interact") && eWasUp)
            {
                levitate = false;
                print("drop");
                player.enableInteract();

                eWasUp = false;
            }
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void stick()
    {
        if (!stuck && equipable)
        {
            stuck = true;
        }
        
    }

    public void lev(float dist)
    {
        if (!levitate)
        {          
            rot = transform.localRotation;
            distance = dist;
            levitate = true;
        }
        
    }

    public void dropAndThrow()
    {
        if (!levitate)
        {
            transform.position = player.cam.transform.position + player.cam.transform.TransformDirection(relPosi);
            GetComponent<Rigidbody>().velocity = player.gameObject.transform.forward * 5;
        }
        release();
    }

    public void release()
    {
        stuck = false;
        levitate = false;
        transform.parent = null;
        player.enableInteract();
    }

    public void interact(InteractControl player)
    {
        float dist = Vector3.Distance(player.gameObject.transform.position, transform.position);
        this.player = player;
        
        if (dist < 5)
        {
            if(equipable)
            {
                handBone = player.getHandBone();
                stick();
                player.setPrimary(this);
            }  
        }
        else
        {
            lev(dist);
            player.setPrimary(this);
        }
    }
}
