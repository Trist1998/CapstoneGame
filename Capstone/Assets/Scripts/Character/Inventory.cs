using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Analytics;

public class Inventory
{
    private List<Item> items;
    

    public Inventory()
    {
        items = new List<Item>();
    }

    public void dropItem(Item item)
    {
        items.Remove(item);
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
