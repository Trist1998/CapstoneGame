using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShrink : ISpell
{
    string name = "Minio";

    //This spell will shrink an object
    public void effect(RaycastHit hit)
    {
        Transform objeck = hit.transform.GetComponent<Transform>();
        objeck.localScale /= 2;
    }

    public string getName()
    {
        return name;
    }

}
