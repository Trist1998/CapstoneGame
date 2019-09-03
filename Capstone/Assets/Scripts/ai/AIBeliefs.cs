using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIBeliefs
{
    public GameObject target;
    public Vector3 targetLastKnownPos;
    public float sightRadius = 5;
    private AICharacter character;

    public AIBeliefs(AICharacter character)
    {
        this.character = character;
    }
    
    public void updateBeliefs()
    {
        if (target == null)
        {
            findTarget();
        }

    }
    
    public void findTarget()
    {
        var objects = Physics.OverlapSphere(character.transform.position, character.beliefs.sightRadius);
        foreach (var colliderObject in objects)
        {
            var cControl = colliderObject.gameObject.GetComponent<AbstractCharacterControl>();
            if (cControl == null) continue;
            if (!character.isCharacterEnemy(cControl)) continue;
            target = cControl.gameObject;
            break;
        }
    }

    public bool isTargetVisible()
    {
        RaycastHit hit;
        Vector3 origin = character.getItemAimPosition();
        Vector3 direction = character.getItemAimPosition() - target.transform.position;
        Debug.DrawRay(origin, direction*sightRadius, Color.green);
        if (Physics.Raycast(origin, direction, out hit, sightRadius))
        {
            return hit.transform.root == target.transform.root;
        }

        return false;
    }

    public float getTargetDistance()
    {
        if (target == null) return -1;
        return (character.transform.position - target.transform.position).magnitude;
    }
}
