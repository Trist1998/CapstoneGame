using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shield : Spell
{
    string name = "Reyouio";

    //This spell will create a defensive shield to protect the player. Will deflect projectiles if well timed
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
