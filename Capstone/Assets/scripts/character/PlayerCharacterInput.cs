﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerCharacterInput : AbstractCharacterInput
{
    public override float getHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float getVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }

    public override bool getJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float getMouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public override float getMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }

    public override bool getPrimaryFireDown()
    {
        return Input.GetButtonDown("Fire1");
    }

    public override bool getPrimaryFireUp()
    {
        return Input.GetButtonUp("Fire1");
    }

    public override bool getSecondaryFireDown()
    {
        return Input.GetButtonDown("Fire2");
    }

    public override bool getSecondaryFireUp()
    {
        return Input.GetButtonUp("Fire2");
    }

    public override bool getInteract()
    {
        return Input.GetButtonDown("Interact");
    }

    public override bool getDropPrimary()
    {
        return Input.GetButtonDown("Drop");
    }
}
