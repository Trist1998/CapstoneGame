using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : Item
{
    private bool fired = false;
    public ParticleSystem muzzleFlash;
    public AudioSource sound;
    public AbstractWeaponEffect spell;

    void Start()
    {
        spell = GetComponent<AbstractWeaponEffect>();
        equipable = true;
    }

    public override void usePrimaryActionDown()//TODO Add checks for resetTime and other checks depending on the unused fields
    {
        if (!fired)
            fire();
        fired = true;
    }

    public override void usePrimaryActionUp()
    {
        fired = false;
    }

    public override void useSecondaryActionDown()
    {
        if (sound != null)
            sound.Play();
        if (muzzleFlash != null)
            muzzleFlash.Play();

        spell.secondaryFire(this);
    }

    public void fire()
    {
        if (sound != null)
            sound.Play();
        if (muzzleFlash != null)
            muzzleFlash.Play();

        spell.primaryFire(this);
    }
}
