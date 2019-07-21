using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : Item
{
    [SerializeField]
    private bool primaryAutomaticFire;
    [SerializeField]
    private bool secondaryAutomaticFire;
    
    private bool fired = false;
    
    [SerializeField]
    private ParticleSystem primaryMuzzleFlash;
    [SerializeField]
    private ParticleSystem secondaryMuzzleFlash;
    
    [SerializeField]
    private AudioSource primarySound;
    [SerializeField]
    private AudioSource secondarySound;
    
    public AbstractWeaponEffect spell;

    [SerializeField]
    private float primaryResetTime;
    [SerializeField]
    private float secondaryResetTime;
    
    private GenericTimer primaryResetTimer;
    private GenericTimer secondaryResetTimer;

    void Start()
    {
        primaryResetTimer = new GenericTimer(primaryResetTime, true);
        secondaryResetTimer = new GenericTimer(secondaryResetTime, true);
        spell = GetComponent<AbstractWeaponEffect>();
    }

    private bool canPrimaryFire()
    {
        if (!primaryResetTimer.isTimeout()) return false;
        if (!primaryAutomaticFire && fired) return false;
        
        fired = true;
        return true;
    }
    
    private bool canSecondaryFire()
    {
        if (!secondaryResetTimer.isTimeout()) return false;
        if (!secondaryAutomaticFire && fired) return false;
        
        fired = true;
        return true;
    }
    
    public override void usePrimaryActionDown()//TODO Add checks for resetTime and other checks depending on the unused fields
    {
        if (!canPrimaryFire()) return;
            primaryFire();
    }

    public override void usePrimaryActionUp()
    {
        fired = false;
    }

    public override void useSecondaryActionDown()
    {
        if (!canSecondaryFire()) return;
            secondaryFire();
    }
    
    public override void useSecondaryActionUp()
    {
        fired = false;
    }

    public void primaryFire()
    {
        if (primarySound != null)
            primarySound.Play();
        if (primaryMuzzleFlash != null)
            primaryMuzzleFlash.Play();

        spell.primaryFire(this);
    }

    public void secondaryFire()
    {
        if (secondarySound != null)
            secondarySound.Play();
        if (secondaryMuzzleFlash != null)
            secondaryMuzzleFlash.Play();

        spell.secondaryFire(this);
    }
}
