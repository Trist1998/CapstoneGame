using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public WorldObject obj;
    [SerializeField]
    private Image health;
    [SerializeField]
    private Image energy;
    [SerializeField]
    private Image star;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        health.fillAmount = obj.hitPoints/obj.maxHitPoints;
        IItemUser player = transform.root.GetComponent<IItemUser>();
        if(player != null && player.getEquippedItem() != null)
            energy.fillAmount = player.getEquippedItem().getAmmoPercentage();
    }

   

    

    
}
