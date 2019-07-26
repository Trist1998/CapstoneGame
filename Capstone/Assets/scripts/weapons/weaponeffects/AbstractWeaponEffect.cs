using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponEffect: MonoBehaviour
{
    public const float DEFAULT_RANGE = 50;

    public ParticleSystem primaryOnHitEffect;
    public ParticleSystem secondaryOnHitEffect;
    public virtual void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        playPrimaryOnHitEffect(hit, hitPoint);
    }

    public virtual void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        playPrimaryOnHitEffect(hit, hitPoint);
    }
    
    public virtual void processPrimaryHit(Item item, GameObject hit)
    {
        processPrimaryHit(item, hit, new Vector3(), new Vector3());
    }
    
    public virtual void primaryFire(Item item)
    {
        RaycastHit hit;
        Vector3 origin = item.user.getItemAimPosition();
        Vector3 direction = item.user.getItemAimDirection();

        if (Physics.Raycast(origin, direction, out hit, getRange()))
        {
            if(hit.transform.root != item.transform.root)
                processPrimaryHit(item, hit.collider.gameObject, hit.point, direction);
        }
    }

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

    protected virtual void playPrimaryOnHitEffect(GameObject hit, Vector3 hitPoint)
    {
        if(primaryOnHitEffect == null) return;
            ParticleSystem effect = hit!=null?Instantiate(primaryOnHitEffect, hit.transform):Instantiate(primaryOnHitEffect);
            effect.transform.position = hitPoint;
            effect.Play();
    }
    
    protected virtual void playSecondaryOnHitEffect(GameObject hit,Vector3 hitPoint)
    {
        if (secondaryOnHitEffect == null) return;
            ParticleSystem effect = Instantiate(secondaryOnHitEffect, hit.transform);
            effect.transform.position = hitPoint;
            effect.Play();
    }
    
    public virtual float getRange()
    {
        return DEFAULT_RANGE;
    }
}


