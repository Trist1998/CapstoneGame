using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Analytics;

public class Inventory
{
    public static readonly string SLOT_PRIMARY = "primary";
    private Dictionary<string, Item> slots;
    private List<Item> items;
    

    public Inventory()
    {
        slots = new Dictionary<string, Item>();
        items = new List<Item>();
    }
    
    public Item getPrimaryItem()
    {
        return getSlotItem(SLOT_PRIMARY);
    }
    
    public void setPrimaryItem(Item item)
    {
        slots[SLOT_PRIMARY] = item;
    }
    
    public void dropPrimary()
    {
        Item primary = getPrimaryItem();
        primary?.release();
        items.Remove(primary);
        setPrimaryItem(null);
    }

    public void dropItem(Item item)
    {
        item.release();
        items.Remove(item);
    }

    public Item getSlotItem(string slotId)
    { 
        if (slots.ContainsKey(slotId))
            return slots[slotId];
        return null;
    }

    public void addItem(Item item)
    {
        items.Add(item);
    }

    public List<Item> getInventoryList()
    {
        return items;
    }


    
}
