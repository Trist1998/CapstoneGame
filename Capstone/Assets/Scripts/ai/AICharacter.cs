using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : AbstractCharacterControl, IItemUser
{
    private bool aiEnabled;
    public GameObject head;
    public GameObject handbone;
    public Item weapon;
    public AIBehaviour[] behaviours;
    public AIBeliefs beliefs;
    public float range;
    


    // Start is called before the first frame update
    void Start()
    {
        behaviours = new AIBehaviour[]{new FollowBehaviour(this, range), new ShootBehaviour(this)};
        beliefs = new AIBeliefs(this);
        unragdoll();
        weapon.user = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!aiEnabled) return;
        beliefs.updateBeliefs();
        foreach (var behaviour in behaviours)
        {
            behaviour.checkConditionAndUpdate();
        }
            
    }

    protected override void die()
    {
        ragdoll();
    }

    public Vector3 getItemAimDirection()
    {
        return head.transform.forward;
    }

    public Vector3 getItemAimPosition()
    {
        return head.transform.position;
    }

    public Item getEquippedItem()
    {
        return weapon;
    }

    public void addItem(Item item)
    {
        weapon = item;
    }

    public GameObject getHandBone()
    {
        return handbone;
    }

    void unragdoll()
    {
        aiEnabled = true;
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<Animator>().enabled = true;
        setRigidbodyState(true);
        setColliderState(false);
    }

    void ragdoll()
    {
        aiEnabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
    }
    
    void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }


    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }
}
