using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    public static readonly string SLOT_PRIMARY = "primary";
    public static readonly string SLOT_SECONDARY = "secondary";
    
    private List<Item> items;
    private Dictionary<string, Item> slots;
    private IItemUser user;
    
    public Inventory(IItemUser user)
    {
        this.user = user;
        
        items = new List<Item>();
        slots = new Dictionary<string, Item>();
    }
    
    /**
     * Adds the item to the inventory
     */
    public void addItem(Item item)
    {
        items.Add(item);
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().detectCollisions = false;
        var primaryTransform = item.transform;
        primaryTransform.parent = user.getHandBone().transform;
        primaryTransform.localPosition = item.relativePosition;
        primaryTransform.rotation = user.getHandBone().transform.rotation;
        primaryTransform.Rotate(item.relativeRotation);
        
        item.gameObject.SetActive(false);
        if(getPrimaryItem() != null)
            setSecondaryItem(getPrimaryItem());
        setPrimaryItem(item);
    }

    /**
     * Returns a list of all the items in the inventory
     */
    public List<Item> getInventoryList()
    {
        return items;
    }
    
    /**
     * Drops the weapon in the primary slot
     */
    public void dropPrimary()
    {
        Item primary = getPrimaryItem();
        dropItem(primary);
        Item secondary = getSecondaryItem();
        setPrimaryItem(secondary);
        if(items.Count() >= 2)
                setSecondaryItem(items[0] == getPrimaryItem()?items[1]:items[0]);
        else
        {
            setSecondaryItem(null);
        }
    }
    
    /**
     * Removes the item from the inventory and sets it back into its original state
     */
    private void dropItem(Item item)
    {
        if (item == null) return;
        item.gameObject.SetActive(true);
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        items.Remove(item);
    }

    /**
     * Returns the current primary Item
     */
    public Item getPrimaryItem()
    {
        if(slots.ContainsKey(SLOT_PRIMARY))
            return slots[SLOT_PRIMARY];
        return null;
    }
    
    /**
     * Sets the primary Item slot
     */
    public void setPrimaryItem(Item item)
    {
        if (item != null)
        {
            slots[SLOT_PRIMARY] = item;
            item.gameObject.SetActive(true);
        }
        else
        {
            slots.Remove(SLOT_PRIMARY);
        }
    }

    /**
     * Returns the current secondary Item
     */
    public Item getSecondaryItem()
    {
        if(slots.ContainsKey(SLOT_SECONDARY))
            return slots[SLOT_SECONDARY];
        return null;
    }
    
    /**
     * Sets the secondary Item slot
     */
    public void setSecondaryItem(Item item)
    {
        if (item != null)
        {
            slots[SLOT_SECONDARY] = item;
            item.gameObject.SetActive(false);
        }
        else
        {
            slots.Remove(SLOT_SECONDARY);
        }
    }

    /**
     * Swaps the secondary and the primary items
     */
    public void swapPrimaryWeapon()
    {
        Item primary = getSecondaryItem();
        setSecondaryItem(getPrimaryItem());
        setPrimaryItem(primary);
    }

    /**
     * Returns the item of a given event
     */
    public Item getSlotItem(string slotId)
    { 
        if (slots.ContainsKey(slotId))
            return slots[slotId];
        return null;
    }
    
}
