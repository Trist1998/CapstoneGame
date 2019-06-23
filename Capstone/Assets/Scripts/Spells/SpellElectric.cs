using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellElectric : ISpell
{
    string name = "Paratacio";

    //This spell will cast electricity
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
