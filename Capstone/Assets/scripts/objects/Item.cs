using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    [SerializeField] 
    private string itemName;
    [SerializeField] 
    private string description;
    [SerializeField]
    public bool equipable;
    
    public Vector3 relativePosition;
    public Vector3 relativeRotation;
    public IItemUser user;

    public void interact(IItemUser user)
    {
        float dist = Vector3.Distance(user.getHandBone().transform.position, transform.position);

        if (user != null && dist < 5)
        {
            user.addItem(this);
        }
    }

    public bool isEquipped()
    {
        return user != null && user.getEquippedItem() == this;
    }

    public virtual void equipItem(IItemUser user)
    {
        this.user = user;
    }
    
    public virtual void unequipItem()
    {
        user = null;
    }
    

    public virtual void usePrimaryActionDown()
    {}

    public virtual void usePrimaryActionUp()
    {}

    public virtual void useSecondaryActionDown()
    {}

    public virtual void useSecondaryActionUp()
    {}

    public virtual string getItemName()
    {
        return itemName;
    }
    
    protected string getItemDescription()
    {
        return description;
    }

    public virtual bool requireAmmoBar()
    {
        return false;
    }
    
    public virtual bool requireComboBar()
    {
        return false;
    }
    
    public virtual float getAmmoPercentage()
    {
        return 0;
    }

    public virtual float getComboPercentage()
    {
        return 0;
    }
    
    public virtual string getDisplayAmmo()
    {
        return "";
    }
    
    public virtual string getDisplayCombo()
    {
        return "";
    }

    public virtual void reload()
    {
    }

    
}
