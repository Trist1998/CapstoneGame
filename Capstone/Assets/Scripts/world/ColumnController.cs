using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class ColumnController : WorldObject
{
    public GameManager manager;
    public Item weapon;
    public int costOfWeapon;
    public int costOfAmmo;
    public int amountOfAmmo;
    public Vector3 relativePos;
    public Vector3 relativeRot;
    public float rotationSpeed;
    protected override void Start()
    {
        instantiateNewWeapon();
        base.Start();
    }
    
    public override void interact(IItemUser user)
    {
        if (user.getEquippedItem()?.GetComponent<AbstractWeaponEffect>()?.getName() ==
            weapon.GetComponent<AbstractWeaponEffect>().getName())
        {
            if (manager.getScore() < costOfAmmo) return;
            user.getEquippedItem().GetComponent<SpellCaster>().addReserveAmmo(amountOfAmmo);
            manager.changeScore(-1*costOfAmmo);
        }
        else
        {
            if (manager.getScore() < costOfWeapon) return;
            user.addItem(weapon);
            manager.changeScore(-1*costOfWeapon);
            instantiateNewWeapon();
            
        }
    }

    private void instantiateNewWeapon()
    {
        weapon = Instantiate(weapon, transform.position, new Quaternion(), null);
        weapon.GetComponent<Collider>().enabled = false;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.transform.parent = transform;
        weapon.transform.Rotate(relativeRot);
        weapon.transform.localPosition += relativePos;
        
    }
    private void FixedUpdate()
    {
        weapon.transform.Rotate(new Vector3(0, rotationSpeed,0) * Time.deltaTime);
    }
}
