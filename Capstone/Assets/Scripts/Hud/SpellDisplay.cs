using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellDisplay : MonoBehaviour
{
    private TextMeshProUGUI spellDisplay;
    [SerializeField]
    private InteractControl ic;
    private Item equippedItem;
    private Inventory inventory;
    private List<Item> items;
    private int position;
    [SerializeField]
    private TextMeshProUGUI next;
    [SerializeField]
    private TextMeshProUGUI prev;
    


    // Start is called before the first frame update
    void Start()
    {
        spellDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        displaySpells();
    }

    void displaySpells()
    {
        inventory = ic.getInventory();
        items = inventory.getInventoryList();
        equippedItem = ic.getEquippedItem();

        if (equippedItem != null)
        {
            spellDisplay.text = equippedItem.getItemName();

            position = items.IndexOf(equippedItem);
            

            if(position == 0)
            {
                prev.text = items[(items.Count-1)].getItemName();
            }

            else
            {
                prev.text = items[position-1].getItemName();
            }

            if (position == items.Count-1)
            {
                next.text = items[0].getItemName();
            }

            else
            {
                next.text = items[(position+1)].getItemName();
            }
        }

        else
        {
            spellDisplay.text = "No spell";
            prev.text = "-";
            next.text = "-";
        }
    }

}
