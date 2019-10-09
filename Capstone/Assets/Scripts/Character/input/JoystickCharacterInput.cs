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
        return controls.Gameplay.Movement.ReadValue<Vector2>().x;
    }

    public override float getVerticalInput()
    {
        return controls.Gameplay.Movement.ReadValue<Vector2>().y;
    }

    public override bool getJump()
    {
        return controls.Gameplay.Jump.triggered;
    }

    public override bool getJumpDown()
    {
        return controls.Gameplay.Jump.triggered;
    }

    public override float getCrouchAxis()
    {
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
        return controls.Gameplay.Rotation.ReadValue<Vector2>().x;
    }

    public override float getMouseY()
    {
        return controls.Gameplay.Rotation.ReadValue<Vector2>().y;
    }

    public override bool getPrimaryFireDown()
    {
        return controls.Gameplay.PrimaryFire.triggered;
 
    }

    public override bool getPrimaryFireUp()
    {
        return !controls.Gameplay.PrimaryFire.triggered;
    }

    public override bool getSecondaryFireDown()
    {
        return controls.Gameplay.SecondaryFire.triggered;
    }

    public override bool getSecondaryFireUp()
    {
        return !controls.Gameplay.SecondaryFire.triggered;
    }

    public override bool getInteract()
    {
        return controls.Gameplay.Interact.triggered;
    }

    public override bool getDropPrimary()
    {
        return controls.Gameplay.Drop.triggered;
    }

    public override bool getPrevItem()
    {
        return controls.Gameplay.Switch1.triggered;
    }

    public override bool getSprintDown()
    {
        return controls.Gameplay.Sprint.triggered;
    }

    public override bool getNextItem()
    {
        return controls.Gameplay.Switch2.triggered;
    }

    public override bool getReload()
    {
        return controls.Gameplay.Reload.triggered;
    }

}
