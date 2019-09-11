using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBehaviour : AIBehaviour
{

    public override bool checkConditionAndUpdate()
    {
        if(character.beliefs.target == null) return false;
        if (character.beliefs.getTargetDistance() > 10) return false;
        update(character);
        return true;
    }

    protected override void update(AICharacter character)
    {
        
        character.head.transform.LookAt(character.beliefs.target.transform);
        character.weapon.usePrimaryActionDown();
        character.weapon.usePrimaryActionUp();
    }

    public ShootBehaviour(AICharacter character) : base(character)
    {
    }
}
