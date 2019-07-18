using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

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
    
}
