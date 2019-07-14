using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon: MonoBehaviour, IItem
{
    public const int FIRE_MODE_FULL_AUTO = 0;
    public const int FIRE_MODE_SEMI_AUTO = 1;
    public const int FIRE_MODE_NOT_AUTO = 2;//IDK

    public int fireModeId;
    public float range = 100;    
    public float bpm = 0.5f;
    public bool projectile = false;
    public int magSize = 20;
    public int spareAmmo = 60;

    bool fired = false;

    public ParticleSystem muzzleFlash;
    public AudioSource sound;
    [SerializeField]
    public AbstractWeaponEffect weaponEffect;

    public void use(ObjectPickup pickup)//TODO Add checks for ammo and resetTime and other checks depending on the unused fields
    {
        //Debug.DrawRay(pickup.fpsCam.transform.position, pickup.fpsCam.transform.forward * range, Color.red);
        if (Input.GetAxis("Fire1") == 1)
        {
            if (!fired)
                fire(pickup);
            fired = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            fired = false;
        }
    }

    public void fire(ObjectPickup pickup)
    {
        if(sound != null)
            sound.Play();
        if(muzzleFlash != null)
            muzzleFlash.Play();
        weaponEffect.fire(pickup);
        
    }
}
