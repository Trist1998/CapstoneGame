using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttract : ISpell
{
    string name = "Tractio";

    //This spell will attract two objects to each other
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
