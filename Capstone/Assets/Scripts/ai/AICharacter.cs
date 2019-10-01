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
    public float sightRange;
    private AIBehaviour currentBehaviour;
    private AIBehaviour root;
    public Rigidbody childBody;


    // Start is called before the first frame update
    void Start()
    {
        behaviours = new AIBehaviour[]{new FollowBehaviour(this, range), new ShootBehaviour(this)};
        root = new AIBehaviour(this, behaviours);
        currentBehaviour = root;
        beliefs = new AIBeliefs(this);
        unragdoll();
        weapon.user = this;
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!aiEnabled) return;
        beliefs.updateBeliefs();
        if (!currentBehaviour.update())
        {
            AIBehaviour b = root.getBehaviourToExecute();
            if(b != null)
                currentBehaviour = b;
        }
        
    }

    public override void destroyObject()
    {
        ragdoll();
        base.destroyObject();
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

    public void unragdoll()
    {
        aiEnabled = true;
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<Animator>().enabled = true;
        setRigidbodyState(true);
        setColliderState(false);
        transform.position = childBody.transform.position;
    }

    public void ragdoll()
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

        if(GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = !state;
    }

    public AIBeliefs getBeliefs()
    {
        if (beliefs == null)
            beliefs = new AIBeliefs(this);
        return beliefs;
        
    }
    
}
