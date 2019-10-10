﻿using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[Serializable]
public class SideStepBehaviour: AIBehaviour
{
    private bool right;
    
    /*
     * Constructor
     */
    public SideStepBehaviour(AICharacter character) : base(character)
    {
        right = Random.Range(0, 1) == 1;
    }
    /*
     * Determines if the behaviour is executable
     */
    protected override bool isExecutable()
    {
        if (character.beliefs.target == null) return false;
        if (character.beliefs.getTargetDistance() > character.range || character.beliefs.isTargetVisible()) return false;
        GameObject obj = character.beliefs.objectAimedAt();
        if (obj != character.beliefs.target.gameObject) return true;
        return false;
    }

    /*
     * Updates the AI behaviour
     */
    public override bool update()
    {
        if (!isExecutable()) return false;
        character.transform.LookAt(character.beliefs.target.transform);
        character.GetComponent<NavMeshAgent>().Warp	(character.transform.position + character.transform.right * (right?1:-1));
        MonoBehaviour.print("Stepping");
        return true;
    }

}
