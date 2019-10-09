using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellForce : AbstractWeaponEffect
{
    public float force;
    public float range;
    public float blastRadius;

    /*
     * Weapon effect for Ezakio
     * 
     */
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Rigidbody rig = hit.GetComponent<Rigidbody>();
        
        if (rig != null)
        {
            AICharacter c = hit.GetComponent<AICharacter>();
            if (c != null)
            {
                c.gameObject.AddComponent<RagdollEffect>().startEffect(1.5f);
                rig = c.childBody;
            }
            rig.AddForce((hit.GetComponent<Collider>().transform.position - item.transform.position).normalized * force);
        }

        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                AICharacter c = colliderObject.GetComponent<AICharacter>();
                if (c != null)
                {
                    c.gameObject.AddComponent<RagdollEffect>().startEffect(1.5f);
                    rigid = c.childBody;
                }
                
                    
                Vector3 displacement = colliderObject.transform.position - hitPoint;
                rigid.AddForce(force * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1) * displacement.normalized);
                
            }
        }
        playPrimaryOnHitEffect(null, hitPoint);
        
    }

    public override float getRange()
    {
        return range;
    }
}



