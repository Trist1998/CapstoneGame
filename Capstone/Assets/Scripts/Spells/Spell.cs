using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spell 
{
    void effect(RaycastHit hit);
    string getName();
}
