using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: MonoBehaviour
{
    public const float DEFAULT_RANGE = 50;

    public ParticleSystem primaryOnHitEffect;
    public Sound primaryOnHitSound;
    public ParticleSystem secondaryOnHitEffect;
    public Sound secondaryOnHitSound;
    public float comboPoints = 0;
    public float maxComboPoints = 1;
    
    
    /**
     * Used to apply the on hit effect and play the particles.
     */
    public virtual void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        playPrimaryOnHitEffect(hit, hitPoint);
        playSound(primaryOnHitSound, hit, hitPoint);
    }

    /**
     * Used to apply the on hit effect and play the particles.
     */
    public virtual void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        playSecondaryOnHitEffect(hit, hitPoint);
        playSound(secondaryOnHitSound, hit, hitPoint);
    }

    private void playSound(Sound sound, GameObject hit, Vector3 hitPoint)
    {
        if (sound.clip == null) return;
        GameObject g = new GameObject();
        g =Instantiate(g, hitPoint, Quaternion.identity);
        AudioSource source = g.AddComponent<AudioSource>();
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.pitch = sound.pitch;
        source.loop = sound.loop;
        source.Play();
        source.spatialBlend = sound.spatialBlend;
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.maxDistance = 200.0f;
        source.minDistance = 1.0f;
        //source.spread = 180;
        Destroy(g, sound.clip.length);
    }

    /**
     * Primary fire of the item
     */
    public virtual void primaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.user.getItemAimPosition();
        Vector3 direction = item.user.getItemAimDirection();
        Debug.DrawRay(origin, direction*getRange(), Color.green);
        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            if(hit.transform.root != item.transform.root)
                processPrimaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

    /**
     * Secondary fire of the item
     */
    public virtual void secondaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.user.getItemAimPosition();
        Vector3 direction = item.user.getItemAimDirection();
        
        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            if(hit.transform.root != item.transform.root)
                processSecondaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

    /**
     * Plays the particle system of the primary fire on hit effect
     */
    protected virtual void playPrimaryOnHitEffect(GameObject hit, Vector3 hitPoint)
    {
        if(primaryOnHitEffect == null) return;
            ParticleSystem effect = hit!=null?Instantiate(primaryOnHitEffect, hit.transform):Instantiate(primaryOnHitEffect);
            effect.transform.position = hitPoint;
            effect.Play();
    }
    
    /**
     * Plays the particle system of the secondary fire on hit effect
     */
    protected virtual void playSecondaryOnHitEffect(GameObject hit,Vector3 hitPoint)
    {
        if (secondaryOnHitEffect == null) return;
            ParticleSystem effect = Instantiate(secondaryOnHitEffect, hit.transform);
            effect.transform.position = hitPoint;
            effect.Play();
    }
    
    /**
     * Override in child for custom ranges
     */
    public virtual float getRange()
    {
        return DEFAULT_RANGE;
    }

    public virtual string getName()
    {
        return "";
    }

    public void addComboPoints(float amount)
    {
        print(amount);
        comboPoints = Mathf.Clamp(comboPoints + amount, 0, maxComboPoints);
    }
}


