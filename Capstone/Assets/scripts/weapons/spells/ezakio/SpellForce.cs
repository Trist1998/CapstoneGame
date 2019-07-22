using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellForce : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Ezakio";
    public float force;
    public float range;

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
    }
}


