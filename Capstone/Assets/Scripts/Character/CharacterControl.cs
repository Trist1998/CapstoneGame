﻿using System;
using UnityEngine;
using System.Collections;

public class CharacterControl : AbstractCharacterControl
{
    public AbstractCharacterInput characterInput;
    public FPSMovementControl movement;
    public InteractControl interactControl;
    public Camera playerCamera;

    protected override void Start()
    {
        base.Start();
        movement = GetComponent<FPSMovementControl>();
        movement?.setValues(playerCamera, characterInput);
        interactControl = GetComponent<InteractControl>();
        interactControl?.setValues(playerCamera, characterInput);
    }

    private void FixedUpdate()
    {
        animator.transform.position = transform.position;
        animator.transform.rotation = transform.rotation;
        animator.SetFloat("velocity", GetComponent<Rigidbody>().velocity.magnitude);
        animator.SetFloat("horizontal", characterInput.getHorizontalInput());
    }
}
