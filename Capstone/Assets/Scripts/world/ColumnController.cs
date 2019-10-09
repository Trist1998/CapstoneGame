using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class ColumnController : MonoBehaviour, IWorldObject
{
    public GameManager manager;
    public Item weapon;
    public Transform itemPos;
    public int costOfWeapon;
    public int costOfAmmo;
    public int amountOfAmmo;
    public Vector3 relativePos;
    public Vector3 relativeRot;
    public float rotationSpeed;
    public float decentSpeed;
    public bool active;//Controls whether or not the column appears between waves
    
    private Vector3 activePosition;
    public float height;

    protected void Start()
    {
        if (manager == null) 
            manager = transform.root.GetComponent<GameManager>();
        instantiateNewWeapon();
        activePosition = transform.position;
        if(!active)
            transform.position -= new Vector3(0,height,0);
    }
    
    public void interact(IItemUser user)
    {
        InteractControl interact = user.getGameObject().GetComponent<InteractControl>();
        if (interact == null) return;
        print("Weapon name " + weapon.getItemName());
        Item item = interact.getInventory().getSlotItem(weapon.getItemName());
        if (item != null)
        {
            if (manager.getScore() < costOfAmmo) return;
            item.GetComponent<WeaponItem>().addReserveAmmo(amountOfAmmo);
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
        weapon.transform.Rotate(relativeRot);
        weapon.transform.parent = itemPos;
        weapon.transform.localPosition = Vector3.zero;//itemPos.transform.position;
        
    }
    private void FixedUpdate()
    {
        itemPos.Rotate(new Vector3(0, rotationSpeed,0) * Time.deltaTime);
        float diff = (activePosition - transform.position).y;
        if (!manager.waveInProgress())
        {
            if (diff > 0)
            {
                transform.position += new Vector3(0, decentSpeed, 0) * Time.deltaTime;
            }
            else
            {
                transform.position = activePosition;
            }
            return;
        }

        if (manager.waveInProgress() && diff > height) return;
        transform.position += new Vector3(0, -1 * decentSpeed, 0) * Time.deltaTime;

    }
}
