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
        IItemUser user = obj.GetComponent<IItemUser>();
        if(user != null && user.getEquippedItem() != null)
            energy.fillAmount = user.getEquippedItem().getAmmoPercentage();
    }

   

    

    
}
