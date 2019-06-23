using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : ISpell
{
    string name = "Fyrio";

    //This spell will shoot fire
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
