using System.Collections;
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

    public override bool getJump()
    {
        return Input.GetButton("Jump");
    }
    
    public override bool getJumpDown()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float getCrouchAxis()
    {
        return Input.GetAxis("Crouch");
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
        return Input.GetButton("Fire1");
    }

    public override bool getPrimaryFireUp()
    {
        return Input.GetButtonUp("Fire1");
    }

    public override bool getSecondaryFireDown()
    {
        return Input.GetButton("Fire2");
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
    
    public override bool getSwapPrimary()
    {
        return Input.GetButtonDown("Swap");
    }

    public override bool getSprintDown()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
}
