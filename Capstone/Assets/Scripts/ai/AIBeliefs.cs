using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class AIBeliefs
{
    public GameObject target;
    public Vector3 targetLastKnownPos;
    public float sightRadius;
    private AICharacter character;

    public AIBeliefs(AICharacter character)
    {
        this.character = character;
        sightRadius = character.sightRange;
    }
    
    public void updateBeliefs()
    {
        if (target == null)
        {
            findTarget();
            if(target == null)
                interCommunicate();
        }
        else
        {
            if (isTargetVisible())
            {
                targetLastKnownPos = target.transform.position;
            }
        }

    }
    
    public void findTarget()
    {
        var objects = Physics.OverlapSphere(character.transform.position, character.beliefs.sightRadius);
        foreach (var colliderObject in objects)
        {
            var cControl = colliderObject.gameObject.GetComponent<AbstractCharacterControl>();
            if (cControl == null) continue;
            if (!character.isCharacterEnemy(cControl) || !isVisible(cControl.gameObject, sightRadius)) continue;
            target = cControl.gameObject;
            break;
        }
    }

    public bool isTargetVisible()
    {
        return target != null && isVisible(target, 1000);
    }

    public GameObject objectAimedAt()
    {
        RaycastHit hit;
        Vector3 origin = character.getItemAimPosition();
        Vector3 direction = character.getItemAimDirection();
        if (Physics.Raycast(origin, direction, out hit, sightRadius))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
    
    public bool isVisible(GameObject obj, float radius)
    {
        RaycastHit hit;
        Vector3 origin = character.getItemAimPosition();
        Vector3 direction = obj.transform.position - character.getItemAimPosition();
        if (Physics.Raycast(origin, direction, out hit, radius))
        {
            return hit.transform.root == obj.transform.root;
        }

        return false;
    }

    public float getTargetDistance()
    {
        if (target == null) return -1;
        return (character.transform.position - target.transform.position).magnitude;
    }

    public void interCommunicate()
    {
        var objects = Physics.OverlapSphere(character.transform.position, character.beliefs.sightRadius);
        foreach (var colliderObject in objects)
        {
            var cControl = colliderObject.gameObject.GetComponent<AICharacter>();
            if (cControl == null) continue;
            if (character.isCharacterEnemy(cControl) || cControl.getBeliefs().target == null) continue;
            target = cControl.beliefs.target;
            break;
        }
    }
    
}
