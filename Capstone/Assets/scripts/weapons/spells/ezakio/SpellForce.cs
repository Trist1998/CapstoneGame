using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellForce : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Ezakio";
    public float force;
    public float range;
    public float blastRadius;

    public override float getRange()
    {
        return range;
    }

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        Rigidbody rig = hit.transform.GetComponent<Rigidbody>();
        if (hit.GetComponent<Collider>().gameObject.GetComponent<Rigidbody>() != null)
        {
            rig.AddForce((hit.GetComponent<Collider>().transform.position - item.transform.position).normalized * force);
        }

        Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
        foreach (var colliderObject in objects)
        {
            Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                Vector3 displacment = colliderObject.transform.position - hitPoint;
                rigid.AddForce(force * Mathf.Pow(Mathf.Clamp(1 - displacment.magnitude/blastRadius, 0, 1), 2) * displacment.normalized);
            }
        }
        playPrimaryOnHitEffect(null, hitPoint);
        
    }
}


