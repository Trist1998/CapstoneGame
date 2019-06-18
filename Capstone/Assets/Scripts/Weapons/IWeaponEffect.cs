using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponEffect
{
    void processHit(GameObject shooter, RaycastHit hit);
}
