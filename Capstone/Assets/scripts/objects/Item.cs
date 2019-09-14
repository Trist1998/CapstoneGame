using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    [SerializeField]
    public bool equipable;
    
    public Vector3 relativePosition;
    public Vector3 relativeRotation;
    public IItemUser user;

    private void equip()
    {
        if (!equipable || user == null) return;
        transform.parent = user.getHandBone().transform;
    }

    public void interact(IItemUser user)
    {
        float dist = Vector3.Distance(user.getHandBone().transform.position, transform.position);

        if (dist < 5)
        {
            this.user = user;
            user.addItem(this);
        }
    }

    public bool isEquipped()
    {
        return user != null && user.getEquippedItem() == this;
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
        return "";
    }

    public virtual float getAmmoPercentage()
    {
        return 0;
    }
}
