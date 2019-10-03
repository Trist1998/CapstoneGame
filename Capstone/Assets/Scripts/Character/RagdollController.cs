using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator animator;
    public bool ragdollAtStart;
    
    private void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if(ragdollAtStart) ragdoll();
        else
        {
            unragdoll();
        }
    }

    public virtual void unragdoll()
    {
        animator.enabled = true;
        setRigidbodyState(true);
        setColliderState(false);
    }

    public virtual void ragdoll()
    {
        animator.enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
    }
    
    protected void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
        if(GetComponent<Rigidbody>() != null)
            GetComponent<Rigidbody>().isKinematic = !state;

    }


    protected void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        if(GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = !state;
    }
}
