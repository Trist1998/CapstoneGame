using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    [SerializeField]
    public bool equipable;
    
    public Vector3 relativePosition;
    public Vector3 relativeRotation;
    public ItemUser user;

    public void interact(InteractControl player)
    {
        float dist = Vector3.Distance(player.gameObject.transform.position, transform.position);

        if (dist < 5)
        {
            this.user = player;
            player.addItem(this);
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
}
