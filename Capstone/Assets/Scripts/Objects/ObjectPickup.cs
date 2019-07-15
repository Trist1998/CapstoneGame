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
	}

    public void stick()
    {
        if (!stuck && equipable)
        {
            stuck = true;
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
    }
}
