using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon: Item
{
    public const int FIRE_MODE_FULL_AUTO = 0;
    public const int FIRE_MODE_SEMI_AUTO = 1;

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

    public override void usePrimaryActionDown()//TODO Add checks for ammo and resetTime and other checks depending on the unused fields
    {
        if (!fired)
            fire();
        fired = true;
    }

    public void fire()
    {
        if(sound != null)
            sound.Play();
        if(muzzleFlash != null)
            muzzleFlash.Play();
        weaponEffect.fire(this);
    }
}
