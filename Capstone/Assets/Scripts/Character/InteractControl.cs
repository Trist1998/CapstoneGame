using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl: MonoBehaviour
{
    public float range = 1000f;
    //public GameObject gameObject;
    public Camera cam;
    [SerializeField]
    private bool interactEnabled = true;
    [SerializeField]
    private ObjectPickup primary;
    private Inventory inventory;
    [SerializeField]
    private GameObject handBone;


    public InteractControl(GameObject gameObject, GameObject handBone,Camera cam)
    {
        //this.gameObject = gameObject;
        inventory = new Inventory();
        this.handBone = handBone;
        this.cam = cam;
    }

    public void control()
    {
        if (Input.GetButtonDown("Interact"))
        {
            cast();
        }
        if(Input.GetButtonDown("Drop"))
        {
            dropPrimary();
        }

        if(primary != null)
        {
            IItem item = primary.gameObject.GetComponent<IItem>();
            if(item != null)
               item.use(primary);
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

    public GameObject getHandBone()
    {
        return handBone;
    }
}
