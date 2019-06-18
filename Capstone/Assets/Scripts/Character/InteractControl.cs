using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl
{
    public float range = 1000f;
    public GameObject gameObject;
    public Camera cam;
    private bool interactEnabled = true;
    private ObjectPickup primary;
    private Inventory inventory;


    public InteractControl(GameObject gameObject, Camera cam)
    {
        this.gameObject = gameObject;
        inventory = new Inventory();
        this.cam = cam;
    }

    public void control()
    {
        if (Input.GetButtonDown("Interact"))
        {
            cast();
        }
        else if(Input.GetButtonDown("Drop"))
        {
            dropPrimary();
        }
    }

    void cast()
    {
        RaycastHit hit;
        if(interactEnabled)
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                WorldObject tar = hit.transform.GetComponent<WorldObject>();
                if (tar != null)
                    tar.interact(this);
            }
    }

    public void disableInteract()
    {
        interactEnabled = false;
    }

    public void enableInteract()
    {
        interactEnabled = true;
    }

    public void setPrimary(ObjectPickup pickup)
    {
        primary = pickup;
        disableInteract();
    }

    public void dropPrimary()
    {
        if (primary != null)
        {
            primary.dropAndThrow();
            primary = null;
            interactEnabled = true;
        }
    }
}
