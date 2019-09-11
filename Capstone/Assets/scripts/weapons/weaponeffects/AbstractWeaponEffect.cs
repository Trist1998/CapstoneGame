using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: MonoBehaviour
{
    public const float DEFAULT_RANGE = 50;

    public ParticleSystem primaryOnHitEffect;
    public ParticleSystem secondaryOnHitEffect;
    
    /**
     * Used to apply the on hit effect and play the particles.
     */
    public virtual void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    /**
     * Used to apply the on hit effect and play the particles.
     */
    public virtual void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        playPrimaryOnHitEffect(hit, hitPoint);
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
}


