using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class SpellElectric : AbstractWeaponEffect
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private LightningBoltScript lightningBolt;
    [SerializeField]
    private LightningBoltScript bigLightningBolt;
    private LightningBoltScript lightning;
    private LightningBoltScript bigLightning;
    [SerializeField]
    private float blastRadius;
    [SerializeField]
    private float blastDamage;
    [SerializeField]
    private float blastForce;

    /*
     * Weapon Effect for Paratacio
     */
    private void Start()
    {
        lightning = Instantiate(lightningBolt, transform.position, Quaternion.identity);
        bigLightning = Instantiate(bigLightningBolt, transform.position, Quaternion.identity);
    }
    
    /*
     * Damages hit object and checks if it is ignitable by checking in the AttachedEffectManager
     * and ignites it if possible
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        WorldObject wO = hit.GetComponent<WorldObject>();
        if(wO != null)
        {
            wO.takeDamage(damage);
            AttachedEffectManager manager = hit.transform.root.GetComponent<AttachedEffectManager>();
            if (manager != null && manager.hasState(AttachedEffectManager.STATE_IGNITABLE))
                manager.getAttachedStates()[AttachedEffectManager.STATE_IGNITABLE].First
                    .endEffect(AttachedEffectManager.STATE_IGNITION);
            lightning.StartPosition = item.transform.position;
            lightning.EndPosition = hitPoint;
            lightning.Trigger();
            addComboPoints(1);
        }
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }
    
    /*
     * Applies damage and force to objects in radius
     */

    public override void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        hit.GetComponent<WorldObject>()?.takeDamage(damage);
        bigLightning.StartPosition = hitPoint + new Vector3(0, 50, 0);
        bigLightning.EndPosition = hitPoint;
        bigLightning.Trigger();
        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid == null) continue;
            WorldObject obj = colliderObject.GetComponent<WorldObject>();
            
            if (obj == null) continue;
            
            Vector3 displacement = colliderObject.transform.position - hitPoint;
            rigid.AddForce(blastForce * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1) * displacement.normalized);
            obj.takeDamage(0.5f * blastDamage * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1));
        }
        
        base.processSecondaryHit(item, hit, hitPoint, direction);
    }

    public override bool canComboFire()
    {
        return true;
    }
}
