using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class FollowBehaviour : AIBehaviour
{
    private bool follow = false;
    private float range;

    protected override bool isExecutable()
    {
        if (character.beliefs.target == null) return false;
        float distance = (character.beliefs.target.transform.position - character.transform.position).magnitude;
        if (distance > range + 10)
        {
            follow = true;
            return true;
        }
        
        if (follow)
        {
            if (distance < range - 2)
            {
                follow = false;
            }
            
                
        }
        else
        {
            if (distance > range + 2)
            {
                follow = true;
            }
        }

        if (follow)
        {
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
        if (isExecutable())
        {
            if(character.beliefs.isTargetVisible())
            {
                character.GetComponent<NavMeshAgent>().SetDestination(character.beliefs.target.transform.position);
            }
            else
            {
                character.GetComponent<NavMeshAgent>().SetDestination(character.beliefs.targetLastKnownPos);
            }
            
            return true;
        }
        else
        {
            character.GetComponent<NavMeshAgent>().SetDestination(character.transform.position);
            return false;
        }
        
        

    }

    public FollowBehaviour(AICharacter character, float range) : base(character)
    {
        this.range = range;
    }
}
