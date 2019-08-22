using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : HealthControl, IItemUser
{
    private bool aiEnabled;
    public GameObject head;
    public GameObject handbone;
    public Item weapon;
    public AIBehaviour currentBehaviour;

    public GameObject target;
    public Vector3 targetLastKnownPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentBehaviour = new FollowBehaviour();
        unragdoll();
        weapon.user = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(aiEnabled)
            if(currentBehaviour.checkCondition(this))
                currentBehaviour.update(this);
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                head.transform.LookAt(target.transform);
                weapon.usePrimaryActionDown();
                weapon.usePrimaryActionUp();
            }
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.magnitude) < 0.05f)
            GetComponent<Animator>().SetInteger("Condition", 0);
        else
            GetComponent<Animator>().SetInteger("Condition", 2);
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
