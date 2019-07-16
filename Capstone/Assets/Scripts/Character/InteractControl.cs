using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl: MonoBehaviour
{
    public float range = 1000f;
    public Camera cam;
    [SerializeField]
    private bool interactEnabled = true;
    private Item primary;
    private Inventory inventory;
    [SerializeField]
    private GameObject handBone;

    public void control()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(primary != null)
                primary.usePrimaryActionDown();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (primary != null)
                primary.usePrimaryActionUp();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            if (primary != null)
                primary.useSecondaryActionDown();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            if (primary != null)
                primary.useSecondaryActionUp();
        }

        if (Input.GetButtonDown("Interact"))
        {
            cast();
        }
        if(Input.GetButtonDown("Drop"))
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
                IWorldObject tar = hit.transform.GetComponent<IWorldObject>();
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

    public void setPrimary(Item item)
    {
        primary = item;
        disableInteract();
    }

    public void dropPrimary()
    {
        if (primary != null)
        {
            primary.release();
            primary = null;
            interactEnabled = true;
        }
    }

    public GameObject getHandBone()
    {
        return handBone;
    }

    public void setHandBone(GameObject handBone)
    {
        this.handBone = handBone;
    }
}
