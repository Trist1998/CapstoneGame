using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCube : MonoBehaviour, IItemUser
{
    [SerializeField]
    private Item weapon;
    private GenericTimer timer;

    private void Start()
    {
        timer = new GenericTimer(2, true);
        weapon.user = this;
    }

    private void Update()
    {
        if(timer.isTimeout())
            weapon.usePrimaryActionDown();
        else
        {
            weapon.usePrimaryActionUp();
        }
    }

    public Vector3 getItemAimDirection()
    {
        return transform.forward;
    }

    public Vector3 getItemAimPosition()
    {
        return weapon.transform.position;
    }

    public Item getEquippedItem()
    {
        return weapon;
    }

    public void addItem(Item item)
    {
        weapon = item;
    }

    public GameObject getHandBone()
    {
        return gameObject;
    }
}
