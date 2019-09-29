using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : Item
{
    [SerializeField]
    private int maxActiveAmmo;
    [SerializeField]
    private int activeAmmo;
    [SerializeField]
    private float primaryReloadTime;
    private GenericTimer primaryReloadTimer;
    
    [SerializeField]
    private int maxReserveAmmo;
    [SerializeField]
    private int reserveAmmo;
    
    [SerializeField]
    private float primaryResetTime;
    [SerializeField]
    private float secondaryResetTime;
    
    private GenericTimer primaryResetTimer;
    private GenericTimer secondaryResetTimer;
    
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
        if (activeAmmo <= 0) return false;
        
        return true;
    }
    
    private bool canSecondaryFire()
    {
        if (!secondaryResetTimer.isTimeout()) return false;
        if (!secondaryAutomaticFire && fired) return false;
        
        fired = true;
        return true;
    }
    
    public override void usePrimaryActionDown()
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
        playParticleEffect(primaryMuzzleFlash);
        spell.primaryFire(this);
        activeAmmo--;
        if(activeAmmo <= 0)
            primaryReloadTimer = new GenericTimer(primaryReloadTime, false);
    }

    private void playParticleEffect(ParticleSystem particles)
    {
        if (particles == null) return;
        ParticleSystem instance = Instantiate(particles, gameObject.transform);
        instance.Play();
    }
    

    public void secondaryFire()
    {
        if (secondarySound != null)
            secondarySound.Play();
        playParticleEffect(secondaryMuzzleFlash);

        spell.secondaryFire(this);
    }

    public override string getItemName()
    {
        return spell != null ? spell.getName() : "No Name";
    }
    
    public override float getAmmoPercentage()
    {
        if(primaryReloadTimer != null)
        {
            if(primaryReloadTimer.isTimeout())
            {
                activeAmmo += maxActiveAmmo - activeAmmo;
                reserveAmmo -= maxActiveAmmo - activeAmmo;
                primaryReloadTimer = null;
            }
            else
            {
                return primaryReloadTimer.getDisplayResetPercent();
            }
        }
        if (maxActiveAmmo == 0) return primaryReloadTimer?.getDisplayResetPercent() ?? 1;

        return activeAmmo/(maxActiveAmmo*1.0f);
    }
}
