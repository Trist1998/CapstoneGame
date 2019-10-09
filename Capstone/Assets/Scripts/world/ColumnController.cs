using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class ColumnController : MonoBehaviour, IWorldObject
{
    [SerializeField]
    private GameManager manager;
    public bool active;//Controls whether or not the column appears between waves
    
    [SerializeField]
    private Item weapon;
    
    [SerializeField]
    private Transform itemPos;
    [SerializeField]
    private int costOfWeapon;
    
    [SerializeField]
    private int costOfAmmo;
    [SerializeField]
    private int amountOfAmmo;
    
    [SerializeField]
    private Vector3 relativeRot;
    [SerializeField]
    private float rotationSpeed;
    
    [SerializeField]
    private float decentSpeed;
    [SerializeField]
    private Sound decentSound;
    
    private GameObject soundObject;
    [SerializeField]
    private Sound buySound;
    
    
    [SerializeField]
    private float height;
    private Vector3 activePosition;
    
    [SerializeField]
    private TextMesh textMesh;
    private GameObject lookAt;
    private bool up;
    
    /*
     * Used to control the Buy columns
     */
    protected void Start()
    {
        if (manager == null) 
            manager = transform.root.GetComponent<GameManager>();
        instantiateNewWeapon();
        activePosition = transform.position;
        if(!active)
            transform.position -= new Vector3(0,height,0);
        textMesh.text = weapon.getItemName() + ": " + costOfWeapon + "\nAmmo: " + costOfAmmo;
        up = active;
    }
    
    /*
     * When the player interactss with the column it checks if they have enough
     * and whether they need ammo or the weapon by checking the inventory
     */
    public void interact(IItemUser user)
    {
        InteractControl interact = user.getGameObject().GetComponent<InteractControl>();
        if (interact == null) return;
        Item item = interact.getInventory().getSlotItem(weapon.getItemName());
        if (item != null)
        {
            WeaponItem weaponItem = item.GetComponent<WeaponItem>();
            if (manager.getScore() < costOfAmmo && weaponItem.getReserveAmmo() != weaponItem.getMaxReserveAmmo()) return;
            weaponItem.addReserveAmmo(amountOfAmmo);
            manager.changePoints(-1*costOfAmmo);
            buySound.playSound(transform.position);
        }
        else
        {
            if (manager.getScore() < costOfWeapon) return;
            user.addItem(weapon);
            manager.changePoints(-1*costOfWeapon);
            instantiateNewWeapon();
            buySound.playSound(transform.position);
        }
    }

    /*
     * Instantiates a new weapon to display
     */
    private void instantiateNewWeapon()
    {
        weapon = Instantiate(weapon, transform.position, new Quaternion(), null);
        weapon.GetComponent<Collider>().enabled = false;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.transform.Rotate(relativeRot);
        weapon.transform.parent = itemPos;
        weapon.transform.localPosition = Vector3.zero;
        
    }
    
    /*
     * Moves the column up and down and make the text face toward the player
     */
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
        if(manager == null)
            return;
        float diff = (activePosition - transform.position).y;
        if (!manager.waveInProgress() && !up)
        {
            if (soundObject == null)
                soundObject = decentSound?.playSound(transform.position);
            textMesh.gameObject.SetActive(lookAt != null);
            transform.position += new Vector3(0, decentSpeed, 0) * Time.deltaTime;
            if (diff <= 0)
            {
                Destroy(soundObject);
                soundObject = null;
                transform.position = activePosition;
                up = true;
            }
            return;
        }

        if (!manager.waveInProgress() || !up) return;

        textMesh.gameObject.SetActive(false);
        if (soundObject == null)
            soundObject = decentSound?.playSound(transform.position);
        transform.position += new Vector3(0, -1 * decentSpeed, 0) * Time.deltaTime;
        if (diff >= height)
        {
            up = false;
            Destroy(soundObject);
            soundObject = null;
        }
    }

    /*
     * Sets the target of the text to look at when the player gets close
     * and hides the text
     */
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<CharacterControl>() != null)
        {
            lookAt = other.gameObject;
            if(!manager.waveInProgress())
                textMesh.gameObject.SetActive(true);
        }
        
    }
    
    /*
     * Removes the target of the text to look at when the player gets far
     * and hides the text
     */
    private void OnTriggerExit(Collider other)
    {
        
        if (other.GetComponent<CharacterControl>() != null)
        {
            lookAt = null;
            textMesh.gameObject.SetActive(false);
        }
    }
}
