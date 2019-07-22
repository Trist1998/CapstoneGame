using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl: MonoBehaviour, ItemUser
{
    public static readonly string SLOT_PRIMARY = "primary";
    
    public float range = 1000f;
    private Camera playerCamera;
    private AbstractCharacterInput characterInput;
    [SerializeField]
    private bool interactEnabled = true;
    private Inventory inventory;
    [SerializeField]
    private GameObject handBone;

    private Dictionary<string, Item> slots;
    private void Start()
    {
        inventory = new Inventory();
        slots = new Dictionary<string, Item>();
    }

    public void control()
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
            dropPrimary();
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
        if (getEquippedItem() == null)
        {
            equipItem(item);
        }
    }

    public void dropPrimary()
    {
        dropItem(getEquippedItem());
        setPrimaryItem(null);
    }
    
    private void dropItem(Item item)
    {
        if (item == null) return;
        
        inventory.dropItem(item);
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
    }
    
    public void equipItem(Item item)
    {
        dropPrimary();
        setPrimaryItem(item);
        
        item.GetComponent<Rigidbody>().isKinematic = true;
        var primaryTransform = item.transform;
        primaryTransform.parent = handBone.transform;
        primaryTransform.localPosition = item.relativePosition;
        primaryTransform.rotation = getHandBone().transform.rotation;
        primaryTransform.Rotate(item.relativeRotation);
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

    public Vector3 getUserAimDirection()
    {
        return playerCamera.transform.forward;
    }
    
    public Vector3 getUserAimPosition()
    {
        return playerCamera.transform.position;
    }

    public Inventory getInventory()
    {
        return inventory;
    }
    
    public void setPrimaryItem(Item item)
    {
        slots[SLOT_PRIMARY] = item;
    }
    
    public Item getEquippedItem()
    {
        return getSlotItem(SLOT_PRIMARY);
    }
    
    public Item getSlotItem(string slotId)
    { 
        if (slots.ContainsKey(slotId))
            return slots[slotId];
        return null;
    }
}
