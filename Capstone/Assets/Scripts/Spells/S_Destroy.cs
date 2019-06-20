using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Destroy : Spell
{
    string name = "Destructio";

    //This spell will devestating damage to an object
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
