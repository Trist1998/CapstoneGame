using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

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
    public Sound decentSound;
    private GameObject soundObject;
    public bool active;//Controls whether or not the column appears between waves
    
    
    private Vector3 activePosition;
    public float height;

    private GameObject lookAt;
    public TextMesh textMesh;

    protected void Start()
    {
        if (manager == null) 
            manager = transform.root.GetComponent<GameManager>();
        instantiateNewWeapon();
        activePosition = transform.position;
        if(!active)
            transform.position -= new Vector3(0,height,0);
        textMesh.text = weapon.getItemName() + ": " + costOfWeapon + "\nAmmo: " + costOfAmmo;
    }
    
    public void interact(IItemUser user)
    {
        InteractControl interact = user.getGameObject().GetComponent<InteractControl>();
        if (interact == null) return;
        Item item = interact.getInventory().getSlotItem(weapon.getItemName());
        if (item != null)
        {
            if (manager.getScore() < costOfAmmo) return;
            item.GetComponent<WeaponItem>().addReserveAmmo(amountOfAmmo);
            manager.changePoints(-1*costOfAmmo);
        }
        else
        {
            if (manager.getScore() < costOfWeapon) return;
            user.addItem(weapon);
            manager.changePoints(-1*costOfWeapon);
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
        if (lookAt != null)
        {
            GameObject obj = textMesh.gameObject;
            Quaternion newRotation = Quaternion.LookRotation (obj.transform.position - lookAt.transform.position,obj.transform.up);
            newRotation.x = 0;
            newRotation.z = 0;
            textMesh.transform.rotation = Quaternion.Lerp (textMesh.transform.rotation,newRotation,Time.deltaTime * 10);
        }
        
        itemPos.Rotate(new Vector3(0, rotationSpeed,0) * Time.deltaTime);
        float diff = (activePosition - transform.position).y;
        if (!manager.waveInProgress())
        {
            textMesh.gameObject.SetActive(lookAt != null);
            if (diff > 0)
            {
                if (soundObject == null)
                    soundObject = decentSound?.playSound(transform.position);
                transform.position += new Vector3(0, decentSpeed, 0) * Time.deltaTime;
            }
            else
            {
                transform.position = activePosition;
            }
            return;
        }

        if (manager.waveInProgress() && diff > height) return;
        textMesh.gameObject.SetActive(false);
        if (soundObject == null)
            soundObject = decentSound?.playSound(transform.position);
        transform.position += new Vector3(0, -1 * decentSpeed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<CharacterControl>() != null)
        {
            lookAt = other.gameObject;
            textMesh.gameObject.SetActive(true);
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.GetComponent<CharacterControl>() != null)
        {
            lookAt = null;
            textMesh.gameObject.SetActive(false);
        }
    }
}
