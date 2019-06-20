using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ : Spell
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
