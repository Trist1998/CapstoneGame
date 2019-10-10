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
    private bool hasCombo = false;
    [SerializeField]
    private float comboPoints;
    [SerializeField]
    public int maxComboPoints;
    
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
    [SerializeField] 
    private Sound cantFireSound;
    
    public AbstractWeaponEffect spell;
    private Recoil recoil;

    
    /*
     * This is the basic weapon object.
     */
    

    void Start()
    {
        primaryResetTimer = new GenericTimer(primaryResetTime, true);
        secondaryResetTimer = new GenericTimer(secondaryResetTime, true);
        spell = GetComponent<AbstractWeaponEffect>();
        recoil = GetComponent<Recoil>();
        if (recoil == null)
            recoil = gameObject.AddComponent<Recoil>();
    }

    /*
     * Called when an IItemUser tries to equip the item
     * Sets the recoil transforms and calls the base equip
     */
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

    public override void usePrimaryActionDown()
    {
        if (canPrimaryFire())
            primaryFire();
 
    }
    
    private bool canPrimaryFire()
    {
        if (!primaryResetTimer.isTimeout()) return false;
        if (!primaryAutomaticFire && fired) return false;
        fired = true;
        if (infiniteAmmo || activeAmmo > 0) return true;
        
        if(cantFireSound != null)
            cantFireSound.playSound(transform.position);
        return false;

    }
    
    public void primaryFire()
    {
        primaryReloadTimer = null;
        if (primarySound != null)
            primarySound.Play();
        recoil.fire();
        playParticleEffect(primaryMuzzleFlash);
        spell.primaryFire(this);
        if(!infiniteAmmo)activeAmmo--;
        if(activeAmmo <= 0 && reserveAmmo > 0)
            reload();
    }
    
    public override void usePrimaryActionUp()
    {
        fired = false;
    }

    public override void useSecondaryActionDown()
    {
        if (canSecondaryFire())
            secondaryFire();

    }
    
    private bool canSecondaryFire()
    {
        if (!secondaryResetTimer.isTimeout()) return false;
        if (!secondaryAutomaticFire && fired) return false;
        if(!spell.canComboFire() && comboPoints < maxComboPoints) return false;
        fired = true;
        return true;
    }
    
    public void secondaryFire()
    {
        if (secondarySound != null)
            secondarySound.Play();
        recoil.fire();
        playParticleEffect(secondaryMuzzleFlash);
        spell.secondaryFire(this);
        comboPoints = 0;
    }
    
    public override void useSecondaryActionUp()
    {
        fired = false;
    }

    private void playParticleEffect(ParticleSystem particles)
    {
        if (particles == null) return;
        ParticleSystem instance = Instantiate(particles, gameObject.transform);
        instance.Play();
    }
    

    public override string getItemName()
    {
        return base.getItemName() + ": " + getItemDescription();
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
        bool reloadWeapon = activeAmmo == 0;
        reserveAmmo += amount;
        reserveAmmo = Mathf.Clamp(reserveAmmo, 0, maxReserveAmmo);
        if (reloadWeapon)
            reload();
    }

    public override void reload()
    {
        primaryReloadTimer = new GenericTimer(primaryReloadTime, false);
    }
    
    public void addComboPoints(float amount)
    {
        comboPoints = Mathf.Clamp(comboPoints + amount, 0, maxComboPoints);
    }
    
    public override float getComboPercentage()
    {
        return comboPoints/(maxComboPoints*1.0f);
    }

    public override string getDisplayAmmo()
    {
        return activeAmmo + "/" + reserveAmmo;
    }

    public override string getDisplayCombo()
    {
        return comboPoints + "/" + maxComboPoints;
    }

    public override bool requireAmmoBar()
    {
        return true;
    }
    
    public override bool requireComboBar()
    {
        return hasCombo;
    }

    public int getReserveAmmo()
    {
        return reserveAmmo;
    }
    
    public int getMaxReserveAmmo()
    {
        return reserveAmmo;
    }
}
