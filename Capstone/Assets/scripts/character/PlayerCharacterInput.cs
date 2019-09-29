using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class PlayerCharacterInput : AbstractCharacterInput
{
    PlayerControls controls;
    public bool controller;
    Vector2 move;
    Vector2 rotate;
    static int playerCount = 0;
    float right;
    float left;
    float forward;
    float backward;

    void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
        move = Vector2.zero;
        rotate = Vector2.zero;

        right = 0;
        left = 0;
        backward = 0;
        forward = 0;
        if (!controls.Gameplay.Join.triggered)
        {
            controller = false;
        }

        else
        {
            controller = true;
        }
        
    }


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
        if (!controller)
        {
            return Input.GetButton("Jump");
           // return controls.MKB.Jump.triggered;
        }

        else
        {
            return controls.Gameplay.Jump.triggered;
        }
    }
    
    public override bool getJumpDown()
    {
        if (!controller)
        {
            return Input.GetButtonDown("Jump");
            //return controls.MKB.Jump.triggered;

        }

        else
        {
            return controls.Gameplay.Jump.triggered;
        }
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
        if (!controller)
        {
            return Input.GetButton("Fire1");
           // return controls.MKB.Primary.triggered;
        }

        else
        {
            return controls.Gameplay.Primary.triggered;
        }
    }

    public override bool getPrimaryFireUp()
    {
        if (!controller)
        {
            return Input.GetButtonUp("Fire1");
            //return controls.MKB.Primary.triggered;
        }

        else
        {
            return controls.Gameplay.Primary.triggered;
        }
    }

    public override bool getSecondaryFireDown()
    {
        if (!controller)
        {
            return Input.GetButton("Fire2");
            //return controls.MKB.Secondary.triggered;
        }

        else
        {
            return controls.Gameplay.Secondary.triggered;
        }
    }

    public override bool getSecondaryFireUp()
    {
        if (!controller)
        {
            return Input.GetButtonUp("Fire2");
            //return controls.MKB.Secondary.triggered;
        }

        else
        {
            return controls.Gameplay.Secondary.triggered;
        }
    }

    public override bool getInteract()
    {
        if (!controller)
        {
            return Input.GetButtonDown("Interact");
            //return controls.MKB.Interact.triggered;
        }

        else
        {
            return controls.Gameplay.Interact.triggered;
        }
    }

    public override bool getDropPrimary()
    {
        if (!controller)
        {
            return Input.GetButtonDown("Drop");
            //return controls.MKB.Drop.triggered; 
        }

        else
        {
            return controls.Gameplay.Drop.triggered;
        }
    }
    
    public override bool getSwapPrimary()
    {
        if (!controller)
        {
            return Input.GetButtonDown("Swap");
            //return controls.MKB.Swap.triggered;
        }

        else
        {
            return controls.Gameplay.Swap.triggered;
        }
    }

    public override bool getSprintDown()
    {
        if (!controller)
        {
            return Input.GetKey(KeyCode.LeftShift);
            //return controls.MKB.Sprint.triggered;

        }

        else
        {
            return controls.Gameplay.Sprint.triggered;
        }
    }
}
