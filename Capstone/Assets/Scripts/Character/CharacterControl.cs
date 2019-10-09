using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterControl : AbstractCharacterControl
{
    [SerializeField]
    private GameManager manager;
    
    [SerializeField]
    private AbstractCharacterInput characterInput;
    
    [SerializeField]
    private FPSMovementControl movement;
    
    [SerializeField]
    private InteractControl interactControl;
    
    [SerializeField]
    private Camera playerCamera;

    [SerializeField] 
    private Text deathText;

    [SerializeField] 
    private GameObject ui;
    

    protected override void Start()
    {
        base.Start();
        if (manager == null)
            manager = transform.parent.parent.GetComponent<GameManager>();
        movement = GetComponent<FPSMovementControl>();
        movement?.setValues(playerCamera, characterInput);
        interactControl = GetComponent<InteractControl>();
        interactControl?.setValues(this, playerCamera, characterInput);
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
        deathText.gameObject.SetActive(true);
        ui.SetActive(false);
        ragdoll();
        manager.playerDead();
        movement.playerCanMove = false;
    }

    public void revive()
    {
        deathText.gameObject.SetActive(false);
        ui.SetActive(true);
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
