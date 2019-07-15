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

    public override float getJumpInput()
    {
        throw new System.NotImplementedException();
    }

    public override float getMouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public override float getMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }

}
