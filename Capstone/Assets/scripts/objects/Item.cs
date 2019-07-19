using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    [SerializeField]
    private bool equipped;
    public bool equipable;

    public InteractControl player;
    public Vector3 relativePosition;
    public Vector3 relativeRotation;

    void onHand()
    {
        if (equipped)
        {
            transform.localPosition = relativePosition;
            transform.rotation = player.getHandBone().transform.rotation;
            transform.Rotate(relativeRotation);
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        onHand();
    }

    public void equip()
    {
        if(!equipped && equipable && player != null)
        {
            transform.parent = player.getHandBone().transform;
            equipped = true;
        }
    }

    public void release()
    {
        player = null;
        equipped = false;
        transform.parent = null;
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
        return equipped;
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
