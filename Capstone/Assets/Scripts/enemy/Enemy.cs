using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : HealthControl, IItemUser
{
    public GameObject target;
    public GameObject head;
    public GameObject handbone;
    public Item weapon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        unragdoll();
        weapon.user = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<NavMeshAgent>().enabled)
            if((target.transform.position - transform.position).magnitude > 5)
                GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                gameObject.transform.LookAt(target.transform);
                weapon.usePrimaryActionDown();
                weapon.usePrimaryActionUp();
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
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<Animator>().enabled = true;
        setRigidbodyState(true);
        setColliderState(false);
    }

    void ragdoll()
    {
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
