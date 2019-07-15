using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellForce : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Ezakio";
    public float force;
    public float range;

    public override float getRange()
    {
        return range;
    }

    public override void processEffect(GameObject toAffect)
    {
        throw new System.NotImplementedException();
    }

    public override void processHit(ObjectPickup shooter, GameObject hit, Vector3 direction)
    {
        Rigidbody rig = hit.transform.GetComponent<Rigidbody>();
        if (hit.GetComponent<Collider>().gameObject.GetComponent<Rigidbody>() != null)
        {
            rig.AddForce((hit.GetComponent<Collider>().transform.position - shooter.transform.position).normalized * force);
        }
    }
}


