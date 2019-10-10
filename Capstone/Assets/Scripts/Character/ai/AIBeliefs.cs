using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[Serializable]
public class AIBeliefs
{
    public WorldObject target;
    public Vector3 targetLastKnownPos;
    public float sightRadius;
    private AICharacter character;

    /*
     *Used to manage the Ai's beliefs
     */
    public AIBeliefs(AICharacter character)
    {
        this.character = character;
        sightRadius = character.sightRange;
    }
    
    /*
     * Observes the current environment and updates beliefs
     */
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
            if(target.isDead())
                findTarget();
            if (isTargetVisible())
            {
                targetLastKnownPos = target.transform.position;
            }
        }

    }
    
    /*
     * Picks a target in its sight range
     */
    public void findTarget()
    {
        var objects = Physics.OverlapSphere(character.transform.position, character.beliefs.sightRadius);
        foreach (var colliderObject in objects)
        {
            var cControl = colliderObject.gameObject.GetComponent<AbstractCharacterControl>();
            if (cControl == null) continue;
            if (!character.isCharacterEnemy(cControl) || !isVisible(cControl.gameObject, sightRadius)) continue;
            target = cControl;
            break;
        }
    }

    /*
     * Chack to see if the target is visible
     */
    public bool isTargetVisible()
    {
        return target != null && isVisible(target.gameObject, sightRadius);
    }

    /*
     * Returns the object the ai is currently aiming at
     */
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
    
    /*
     * Checks if the game object is visible
     */
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

    /*
     * Returns the distance to the target
     */
    public float getTargetDistance()
    {
        if (target == null) return -1;
        return (character.transform.position - target.transform.position).magnitude;
    }

    /*
     * Talk to other AI's to exchange information
     */
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
