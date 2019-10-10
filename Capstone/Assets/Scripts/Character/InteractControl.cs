using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour, IItemUser
{

    public float range = 1000f;
    private Camera playerCamera;
    private AbstractCharacterInput characterInput;
    [SerializeField] 
    private bool interactEnabled = true;
    [SerializeField]
    private Inventory inventory;
    [SerializeField] 
    private GameObject handBone;
    [SerializeField] 
    private GameObject handBoneCharacter;
    [SerializeField]
    private CharacterControl control;

    /*
     * Interact Control Controls the interaction between the player and the outside world
     * Implements IItemUser
     */

    private void Start()
    {
        inventory = new Inventory(this);
    }

    /*
     * Update used to check for character inputs
     */
    private void Update()
    {
        if(control.isDead()) return;
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

        if (characterInput.getReload())
        {
            getEquippedItem().reload();
        }
        if (characterInput.getNextItem())
        {
            inventory.nextItem();
        }

        if (characterInput.getPrevItem())
        {
            inventory.prevItem();
        }
        else if (characterInput.getDropPrimary())
        {
            inventory.dropPrimary();
        }

    }

    /*
     * Interaction
     * Casts a ray, checks for a worldobject and interacts with it
     */
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

    /*
     * Disables the character's ability to interact
     */
    public void disableInteract()
    {
        interactEnabled = false;
    }

    /*
     * Enables the character's ability to interact
     */
    public void enableInteract()
    {
        interactEnabled = true;
    }
    
    /*
     * Adds the item to the player's inventory
     */
    public void addItem(Item item)
    {
        inventory.addItem(item);
    }
    
   /*
    * Returns the handbone required for the 3rd person model render
    */
   public GameObject getHandBoneCharacter()
    {
        return handBoneCharacter;
    }

    /*
     * Sets up the initial values
     */
    public void setValues(CharacterControl control, Camera playerCamera, AbstractCharacterInput input)
    {
        this.control = control;
        this.playerCamera = playerCamera;
        characterInput = input;
    }
    
    /*
     * IItemUser Implementation
     */
    public Item getEquippedItem()
    {
        return inventory?.getPrimaryItem();
    }
    
    public GameObject getHandBone()
    {
        return handBone;
    }
    
    public void setHandBone(GameObject handBone)
    {
        this.handBone = handBone;
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
    
    public GameObject getGameObject()
    {
        return gameObject;
    }

    
}