using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class FollowBehaviour : AIBehaviour
{
    private bool follow = false;
    private float range;
    
    public override bool executable()
    {
        if (character.beliefs.target == null) return false;
        float distance = (character.beliefs.target.transform.position - character.transform.position).magnitude;
        follow = (distance > range + 2 && follow) || (distance > range && !follow);

        if (follow)
        {
            update();
            character.GetComponent<Animator>().SetInteger("Condition", 2);
        }
        else
        {
            character.GetComponent<Animator>().SetInteger("Condition", 0);
        }
        return follow;
    }

    public override bool update()
    {
        if(character.beliefs.isTargetVisible())
        {
            character.GetComponent<NavMeshAgent>().SetDestination(character.beliefs.target.transform.position);
        }
        else
        {
            character.GetComponent<NavMeshAgent>().SetDestination(character.beliefs.targetLastKnownPos);
        }
    }

    public FollowBehaviour(AICharacter character, float range) : base(character)
    {
        this.range = range;
    }
}
