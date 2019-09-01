using UnityEngine;
using UnityEngine.AI;

public class FollowBehaviour : AIBehaviour
{
    private bool follow = false;
    private float range;
    
    public override bool checkConditionAndUpdate()
    {
        if (character.beliefs.target == null) return false;
        float distance = (character.beliefs.target.transform.position - character.transform.position).magnitude;
        follow = (distance > range && follow) || (distance > range + 2 && !follow);

        if (follow)
        {
            update(character);
            character.GetComponent<Animator>().SetInteger("Condition", 2);
        }
        else
        {
            character.GetComponent<Animator>().SetInteger("Condition", 0);
        }
        return follow;

    }

    protected override void update(AICharacter character)
    {
        character.GetComponent<NavMeshAgent>().SetDestination(character.beliefs.target.transform.position);
    }

    public FollowBehaviour(AICharacter character, float range) : base(character)
    {
        this.range = range;
    }
}
