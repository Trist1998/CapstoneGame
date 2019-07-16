using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    private bool equipped;
    public bool equipable;

    public InteractControl player;
    public GameObject handBone;
    public Vector3 relativePosition;
    public Vector3 relativeRotation;

    void onHand()
    {
        if (equipped)
        {
            transform.localPosition = relativePosition;
            transform.rotation = handBone.transform.rotation;
            transform.Rotate(relativeRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        onHand();
    }

    public void stick()
    {
        if (!equipped && equipable)
        {
            transform.parent = handBone.transform;
            equipped = true;
        }
    }

    public void release()
    {
        equipped = false;
        transform.parent = null;
        player.enableInteract();
    }

    public void interact(InteractControl player)
    {
        float dist = Vector3.Distance(player.gameObject.transform.position, transform.position);
        this.player = player;

        if (dist < 5)
        {
            if (equipable)
            {
                handBone = player.getHandBone();
                stick();
                player.setPrimary(this);
            }
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
