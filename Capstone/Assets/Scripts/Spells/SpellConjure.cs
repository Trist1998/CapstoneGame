using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellConjure : ISpell
{
    string name = "Conjurio";

    //This spell will summon a spirit animal conjuration
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
