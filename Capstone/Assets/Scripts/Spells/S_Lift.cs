using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Lift : Spell
{
    string name = "Asensio";

    //This spell will lift an object and allow the player to toss it
    public void effect(RaycastHit hit)
    {

    }

    public string getName()
    {
        return name;
    }
}
