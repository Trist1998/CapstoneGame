using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public WorldObject obj;
    [SerializeField]
    private Image healthContent;
    [SerializeField]
    private Image energyContent;
    [SerializeField]
    private Image starContent;
    [SerializeField]
    private GameObject health;
    [SerializeField]
    private GameObject energy;
    [SerializeField]
    private GameObject star;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        healthContent.fillAmount = obj.hitPoints/obj.maxHitPoints;
        health.GetComponentInChildren<Text>().text = ((int)obj.hitPoints)+"/"+obj.maxHitPoints;
        IItemUser user = obj.GetComponent<IItemUser>();
        if (user != null && user.getEquippedItem() != null)
        {
            Item item = user.getEquippedItem();
            if (item.requireAmmoBar())
            {
                energy.SetActive(true);
                energy.GetComponentInChildren<Text>().text = item.getDisplayAmmo();
                energyContent.fillAmount = user.getEquippedItem().getAmmoPercentage();
            }

            if (item.requireComboBar())
            {
                star.SetActive(true);
                starContent.fillAmount = user.getEquippedItem().getComboPercentage();
                star.GetComponentInChildren<Text>().text = item.getDisplayCombo();
            }
            
        }
        else
        {
            energy.SetActive(false);
            star.SetActive(false);
        }
            
    }

   

    

    
}
