using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideStepBehaviour: AIBehaviour
{
    private bool right;
    protected override bool isExecutable()
    {
        if (character.beliefs.target == null) return false;
        if (character.beliefs.getTargetDistance() > character.range || character.beliefs.isTargetVisible()) return false;
        GameObject obj = character.beliefs.objectAimedAt();
        if (obj != character.beliefs.target.gameObject) return true;
        return false;
    }

    public override bool update()
    {
        if (!isExecutable()) return false;
        character.transform.LookAt(character.beliefs.target.transform);
        character.GetComponent<Rigidbody>().AddForce(character.transform.right * (right?1:-1));
        MonoBehaviour.print("Stepping");
        return true;
    }

    public SideStepBehaviour(AICharacter character) : base(character)
    {
        right = Random.Range(0, 1) == 1;
    }
    
}
