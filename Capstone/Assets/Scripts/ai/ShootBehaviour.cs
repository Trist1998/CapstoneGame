using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBehaviour : AIBehaviour
{

    protected override bool isExecutable()
    {
        if (base.isExecutable())
            return base.update();
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
        character.head.transform.LookAt(character.beliefs.target.transform);
        character.weapon.usePrimaryActionDown();
        character.weapon.usePrimaryActionUp();
        return true;
    }

    public ShootBehaviour(AICharacter character) : base(character)
    {
        behaviours = new AIBehaviour[]{new SideStepBehaviour(character)};
    }
}
