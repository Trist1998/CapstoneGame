using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBehaviour : AIBehaviour
{
    private float aimSpeed;

    protected override bool isExecutable()
    {
        if (base.isExecutable())
            return base.update();
        if (character.weapon.getAmmoPercentage() <= 0) return false;
        if(character.beliefs.target == null) return false;
        if (character.beliefs.getTargetDistance() > character.range) return false;

        return true;
    }

    /**
     * Used to perform AI actions
     * Returns true if still executing
     */
    public override bool update()
    {
        if (!isExecutable()) return false;
        aimCharacter(character.beliefs.target);
        aimGun(character.beliefs.target);
        character.weapon.usePrimaryActionDown();
        character.weapon.usePrimaryActionUp();
        return true;
    }
    private void aimCharacter(GameObject target)
    {
        GameObject obj = character.gameObject;
        Quaternion newRotation = Quaternion.LookRotation (obj.transform.position - target.transform.position,-obj.transform.up);
        newRotation.x = 0;
        newRotation.z = 0;
        character.transform.rotation = Quaternion.Lerp (character.transform.rotation,newRotation,Time.deltaTime * aimSpeed);
    }

    private void aimGun(GameObject target)
    {
        GameObject obj = character.head;
        Quaternion newRotation = Quaternion.LookRotation (target.transform.position - obj.transform.position ,obj.transform.up);
        newRotation = Quaternion.Lerp (character.head.transform.rotation,newRotation,Time.deltaTime * aimSpeed/5);
        character.head.transform.rotation = newRotation;
    }
    
    public ShootBehaviour(AICharacter character, float aimSpeed) : base(character)
    {
        behaviours = new AIBehaviour[]{new SideStepBehaviour(character)};
        this.aimSpeed = aimSpeed;
    }
}
