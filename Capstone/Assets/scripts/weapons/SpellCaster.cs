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
        equipable = true;
    }

    protected void Update()
    {
        base.Update();
        primaryResetTimer?.updateTimer(Time.deltaTime);
        secondaryResetTimer?.updateTimer(Time.deltaTime);
    }

    public override void usePrimaryActionDown()//TODO Add checks for resetTime and other checks depending on the unused fields
    {
        if (!primaryResetTimer.isTimeout()) return;
            if (!primaryAutomaticFire)
            {
                if (!fired)
                    primaryFire();
                fired = true;
            }
            else
            {
                primaryFire();
            }
        
    }

    public override void usePrimaryActionUp()
    {
        fired = false;
    }

    public override void useSecondaryActionDown()
    {
        if (!secondaryResetTimer.isTimeout()) return;
            if (!secondaryAutomaticFire)
            {
                if (!fired)
                    secondaryFire();
                fired = true;
            }
            else
            {
                secondaryFire();
            }
        
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
