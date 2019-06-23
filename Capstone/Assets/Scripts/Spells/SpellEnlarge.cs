using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEnlarge : ISpell
{
    string name = "Maxio";

    //This spell will enlarge an object
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }

}
