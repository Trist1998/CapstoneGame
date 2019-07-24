using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static readonly string SLOT_PRIMARY = "primary";
    
    private List<Item> items;
    private Dictionary<string, Item> slots;
    private IItemUser user;
    
    public Inventory(IItemUser user)
    {
        this.user = user;
        
        items = new List<Item>();
        slots = new Dictionary<string, Item>();
    }
    
    public void addItem(Item item)
    {
        items.Add(item);
        if (getEquippedItem() == null)
        {
            equipItem(item);
        }
    }

    public List<Item> getInventoryList()
    {
        return items;
    }
    
    public void dropPrimary()
    {
        dropItem(getEquippedItem());
        setPrimaryItem(null);
    }
    
    private void dropItem(Item item)
    {
        if (item == null) return;
        
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
        items.Remove(item);
    }
    
    public void equipItem(Item item)
    {
        dropPrimary();
        setPrimaryItem(item);
        
        item.GetComponent<Rigidbody>().isKinematic = true;
        var primaryTransform = item.transform;
        primaryTransform.parent = user.getHandBone().transform;
        primaryTransform.localPosition = item.relativePosition;
        primaryTransform.rotation = user.getHandBone().transform.rotation;
        primaryTransform.Rotate(item.relativeRotation);
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
