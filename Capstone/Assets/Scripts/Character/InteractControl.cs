using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl: MonoBehaviour
{
    public float range = 1000f;
    private Camera playerCamera;
    private AbstractCharacterInput characterInput;
    [SerializeField]
    private bool interactEnabled = true;
    private Inventory inventory;
    [SerializeField]
    private GameObject handBone;

    void Start()
    {
        inventory = new Inventory();
    }

    public void control()
    {
        Item primary = inventory.getPrimaryItem();
        if (primary != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                primary.usePrimaryActionDown();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                primary.usePrimaryActionUp();
            }
            else if(Input.GetButtonDown("Fire2"))
            {
                primary.useSecondaryActionDown();
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                primary.useSecondaryActionUp();
            }
        }
        
        if (Input.GetButtonDown("Interact"))
        {
            cast();
        }
        if(Input.GetButtonDown("Drop"))
        {
            inventory.dropPrimary();
        }
    }

    private void cast()
    {
        RaycastHit hit;
        if(interactEnabled)
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
            {
                IWorldObject tar = hit.transform.GetComponent<IWorldObject>();
                tar?.interact(this);
            }
    }

    public void addItem(Item item)
    {
        inventory.addItem(item);
        if (inventory.getPrimaryItem() == null)
        {
            equipItem(item);
        }
            
    }

    public void equipItem(Item item)
    {
        inventory.setPrimaryItem(item);
        item.equip();
    }

    public void disableInteract()
    {
        interactEnabled = false;
    }

    public void enableInteract()
    {
        interactEnabled = true;
    }

    public GameObject getHandBone()
    {
        return handBone;
    }

    public void setHandBone(GameObject handBone)
    {
        this.handBone = handBone;
    }
    
    public void setValues(Camera playerCamera, AbstractCharacterInput input)
    {
        this.playerCamera = playerCamera;
        this.characterInput = input;
    }

    public Vector3 getPlayerCameraDirection()
    {
        return playerCamera.transform.forward;
    }
    
    public Vector3 getPlayerCameraPosition()
    {
        return playerCamera.transform.position;
    }
    
}
