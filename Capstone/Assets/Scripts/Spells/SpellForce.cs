using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellForce : ISpell
{
    string name = "Ezakio";

    //Will perform the spell's effect and push the object or enemy away
    public void effect(RaycastHit hit)
    {
        Rigidbody rig = hit.transform.GetComponent<Rigidbody>();
        rig.AddForce(hit.transform.forward * 750, ForceMode.Force);
        rig.useGravity = true;
    }

    public string getName()
    {
        return name;
    }

 
}


