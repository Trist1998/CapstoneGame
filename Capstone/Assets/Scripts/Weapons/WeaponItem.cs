using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    [SerializeField]
    private bool infiniteAmmo;
    [SerializeField]
    private int maxActiveAmmo;
    [SerializeField]
    private int activeAmmo = 1;
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
    public AudioSource primarySound;
    [SerializeField]
    private AudioSource secondarySound;
    
    public AbstractWeaponEffect spell;
    private Recoil recoil;

    

    void Start()
    {
        primaryResetTimer = new GenericTimer(primaryResetTime, true);
        secondaryResetTimer = new GenericTimer(secondaryResetTime, true);
        spell = GetComponent<AbstractWeaponEffect>();
        recoil = GetComponent<Recoil>();
        if (recoil == null)
            recoil = gameObject.AddComponent<Recoil>();
    }

    public override void equipItem(IItemUser user)
    {
        recoil.setTransforms(user);
        base.equipItem(user);
    }
    
    public override void unequipItem()
    {
        recoil.resetTransforms();
        base.unequipItem();
    }

    private bool canPrimaryFire()
    {
        if (!primaryResetTimer.isTimeout()) return false;
        if (!primaryAutomaticFire && fired) return false;
        fired = true;
        if (!infiniteAmmo && activeAmmo <= 0) return false;
        
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
        recoil.fire();
        playParticleEffect(primaryMuzzleFlash);
        spell.primaryFire(this);
        if(!infiniteAmmo)activeAmmo--;
        if(activeAmmo <= 0 && reserveAmmo > 0)
            reload();
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
        recoil.fire();
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
                int ammoRequired = maxActiveAmmo - activeAmmo;
                if (reserveAmmo >= ammoRequired)
                {
                    activeAmmo += ammoRequired;
                    reserveAmmo -= ammoRequired;
                }
                else
                {
                    activeAmmo += reserveAmmo;
                    reserveAmmo = 0;
                }
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

    public void addReserveAmmo(int amount)
    {
        bool reloadWeapon = reserveAmmo == 0;
        reserveAmmo += amount;
        reserveAmmo = Mathf.Clamp(reserveAmmo, 0, maxReserveAmmo);
        if (reloadWeapon)
            reload();
    }

    public void reload()
    {
        primaryReloadTimer = new GenericTimer(primaryReloadTime, false);
    }
    
    public override float getComboPercentage()
    {
        return spell.comboPoints/spell.maxComboPoints;
    }

    public override string getDisplayAmmo()
    {
        return activeAmmo + "/" + reserveAmmo;
    }

    public override string getDisplayCombo()
    {
        return spell.comboPoints + "/" + spell.maxComboPoints;
    }

}
