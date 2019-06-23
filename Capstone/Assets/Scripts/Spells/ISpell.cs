using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell 
{
    void effect(RaycastHit hit);
    string getName();
}
