using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    [SerializeField]
    public bool equipable;
    
    public Vector3 relativePosition;
    public Vector3 relativeRotation;
    public IItemUser player;

    private void equip()
    {
        if (!equipable || player == null) return;
        transform.parent = player.getHandBone().transform;
    }

    public void interact(InteractControl player)
    {
        float dist = Vector3.Distance(player.gameObject.transform.position, transform.position);

        if (dist < 5)
        {
            this.player = player;
            player.addItem(this);
        }
    }

    public bool isEquipped()
    {
        return player != null && player.getEquippedItem() == this;
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
