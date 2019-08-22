using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowBehaviour : AIBehaviour
{
    public override bool checkCondition(AICharacter character)
    {
        return (character.target.transform.position - character.transform.position).magnitude > 5;

    }

    public override void update(AICharacter character)
    {
        character.GetComponent<NavMeshAgent>().SetDestination(character.target.transform.position);
    }
}
