using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour, IItemUser
{

    public float range = 1000f;
    private Camera playerCamera;
    private AbstractCharacterInput characterInput;
    [SerializeField] private bool interactEnabled = true;
    private Inventory inventory;
    [SerializeField] private GameObject handBone;


    private void Start()
    {
        inventory = new Inventory(this);
    }

    private void Update()
    {
        Item primary = getEquippedItem();
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
            else if (characterInput.getSecondaryFireDown())
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

        if (characterInput.getNextItem())
        {
            inventory.nextItem();
        }

        if (characterInput.getSwapPrimary())
        {
            inventory.swapPrimaryWeapon();
        }
        else if (characterInput.getDropPrimary())
        {
            inventory.dropPrimary();
        }

    }

    private void cast()
    {
        RaycastHit hit;
        if (interactEnabled)
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
            {
                IWorldObject tar = hit.transform.GetComponent<IWorldObject>();
                tar?.interact(this);
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

    public Item getEquippedItem()
    {
        if (inventory == null)
            return null;
        return inventory.getPrimaryItem();
    }

    public void addItem(Item item)
    {
        inventory.addItem(item);
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

    public Vector3 getItemAimDirection()
    {
        return playerCamera.transform.forward;
    }

    public Vector3 getItemAimPosition()
    {
        return playerCamera.transform.position;
    }

    public Inventory getInventory()
    {
        return inventory;
    }
}