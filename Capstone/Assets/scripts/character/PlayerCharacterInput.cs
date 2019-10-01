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
        //if (!controls.Gameplay.Join.triggered)
        {
            controller = false;
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
        return Input.GetButtonDown("Swap");
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
