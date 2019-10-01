using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JoystickCharacterInput : AbstractCharacterInput
{
    PlayerControls controls;
    Vector2 move;
    Vector2 rotate;

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();

        move = Vector2.zero;
        rotate = Vector2.zero;
    }

    public override float getHorizontalInput()
    {
        // return Input.GetAxis("Horizontal");
        return controls.Gameplay.Movement.ReadValue<Vector2>().x;
    }

    public override float getVerticalInput()
    {
        //return Input.GetAxis("Vertical");
        return controls.Gameplay.Movement.ReadValue<Vector2>().y;
    }

    public override bool getJump()
    {
        //return Input.GetButton("Jump");
        return controls.Gameplay.Jump.triggered;
    }

    public override bool getJumpDown()
    {
        //return Input.GetButtonDown("Jump");
        return controls.Gameplay.Jump.triggered;
    }

    public override float getCrouchAxis()
    {
        //return Input.GetAxis("Crouch");
        bool press = false;
        controls.Gameplay.Crouch.performed += ctx => press = ctx.canceled;

        if (press)
        {
            return 1;
        }

        else
        {
            return 0;
        }

    }

    public override float getMouseX()
    {
        //return Input.GetAxis("Mouse X");
        return controls.Gameplay.Rotation.ReadValue<Vector2>().x;
    }

    public override float getMouseY()
    {
        // return Input.GetAxis("Mouse Y");
        return controls.Gameplay.Rotation.ReadValue<Vector2>().y;
    }

    public override bool getPrimaryFireDown()
    {
        //return Input.GetButton("Fire1");
        return controls.Gameplay.PrimaryFire.triggered;
 
    }

    public override bool getPrimaryFireUp()
    {
        //return Input.GetButtonUp("Fire1");
        return !controls.Gameplay.PrimaryFire.triggered;
    }

    public override bool getSecondaryFireDown()
    {
        // return Input.GetButton("Fire2");
        return controls.Gameplay.SecondaryFire.triggered;
    }

    public override bool getSecondaryFireUp()
    {
        //  return Input.GetButtonUp("Fire2");
        return controls.Gameplay.SecondaryFire.triggered;
    }

    public override bool getInteract()
    {
        //return Input.GetButtonDown("Interact");
        return controls.Gameplay.Interact.triggered;
    }

    public override bool getDropPrimary()
    {
        //return Input.GetButtonDown("Drop");
        return controls.Gameplay.Drop.triggered;
    }

    public override bool getSwapPrimary()
    {
        //return Input.GetButtonDown("Swap");
        return controls.Gameplay.Switch1.triggered;
    }

    public override bool getSprintDown()
    {
        //return Input.GetKey(KeyCode.LeftShift);
        return controls.Gameplay.Sprint.triggered;
    }
}
