using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTrap : ISpell
{
    string name = "Trapio";

    //This spell will place a trap on the floor
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
