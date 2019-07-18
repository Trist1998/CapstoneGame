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
            if (characterInput.getPrimaryFireDown())
            {
                primary.usePrimaryActionDown();
            }
            else if (characterInput.getPrimaryFireUp())
            {
                primary.usePrimaryActionUp();
            }
            else if(characterInput.getSecondaryFireDown())
            {
                primary.useSecondaryActionDown();
            }
            else if (characterInput.getSecondaryFireUp())
            {
                primary.useSecondaryActionUp();
            }
        }
        
        if (characterInput.getInteract())
        {
            cast();
        }
        if(characterInput.getDropPrimary())
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
