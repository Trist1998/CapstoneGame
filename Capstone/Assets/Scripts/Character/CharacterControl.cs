using System;
using UnityEngine;
using System.Collections;

public class CharacterControl : AbstractCharacterControl
{
    public GameManager manager;
    public AbstractCharacterInput characterInput;
    public FPSMovementControl movement;
    public InteractControl interactControl;
    public Camera playerCamera;

    protected override void Start()
    {
        base.Start();
        if (manager == null)
            manager = transform.parent.parent.GetComponent<GameManager>();
        movement = GetComponent<FPSMovementControl>();
        movement?.setValues(playerCamera, characterInput);
        interactControl = GetComponent<InteractControl>();
        interactControl?.setValues(playerCamera, characterInput);
    }

    private void FixedUpdate()
    {
        if(isDead()) return;
        animator.transform.position = transform.position;
        animator.transform.rotation = transform.rotation;
        animator.SetFloat("velocity", GetComponent<Rigidbody>().velocity.magnitude);
        animator.SetFloat("horizontal", characterInput.getHorizontalInput());
    }

    protected override void die()
    {
        ragdoll();
        manager.playerDead();
        movement.playerCanMove = false;
    }

    public void revive()
    {
        unragdoll();
        manager.revivePlayer();
        movement.playerCanMove = true;
        hitPoints = maxHitPoints * 0.4f;
    }

    public override void interact(IItemUser user)
    {
        if(manager.tryRevive())
            revive();
    }
}
