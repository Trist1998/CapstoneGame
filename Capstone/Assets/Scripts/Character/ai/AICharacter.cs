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
    protected override void Start()
    {
        base.Start();
        behaviours = new AIBehaviour[]{new FollowBehaviour(this, range), new ShootBehaviour(this)};
        root = new AIBehaviour(this, behaviours);
        currentBehaviour = root;
        beliefs = new AIBeliefs(this);
        unragdoll();
        if (handbone != null && weapon == null)
            weapon = handbone.GetComponentInChildren<Item>();
        weapon.user = this;
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

    public AIBeliefs getBeliefs()
    {
        if (beliefs == null)
            beliefs = new AIBeliefs(this);
        return beliefs;
    }

    public override void ragdoll()
    {
        aiEnabled = false;
        base.ragdoll();
    }

    public override void unragdoll()
    {
        base.unragdoll();
        transform.position = childBody.transform.position;
        aiEnabled = true;
    }
}
