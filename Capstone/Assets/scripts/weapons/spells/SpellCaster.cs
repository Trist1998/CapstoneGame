using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour, IItem
{
    private bool fired = false;
    public ParticleSystem muzzleFlash;
    public AudioSource sound;
    public AbstractWeaponEffect spell;

    public void use(ObjectPickup pickup)//TODO Add checks for resetTime and other checks depending on the unused fields
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
        if (sound != null)
            sound.Play();
        if (muzzleFlash != null)
            muzzleFlash.Play();

        spell.fire(pickup);
    }
}
