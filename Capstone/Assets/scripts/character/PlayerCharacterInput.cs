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
        if (!controller)
        {
             return Input.GetAxis("Horizontal");
      /*      controls.MKB.Right.performed += ctx => right = 1;
            controls.MKB.Right.canceled += ctx => right = 0;


            controls.MKB.Left.performed += ctx => left = 1;
            controls.MKB.Left.canceled += ctx => left = 0;

            if (right==1)
            {
                return 1;
            }

            else if (left==1)
            {
                return -1;
            }

            else
            {
                return 0;
            }*/
        }

        else
        {
            return controls.Gameplay.Move.ReadValue<Vector2>().x;
        }
    }

    public override float getVerticalInput()
    {
        if (!controller)
        {
            controls.MKB.Forward.performed += ctx => forward = 1;
            controls.MKB.Forward.canceled += ctx => forward = 0;


            controls.MKB.Backward.performed += ctx => backward = 1;
            controls.MKB.Backward.canceled += ctx => backward = 0;

            if (forward == 1)
            {
                return 1;
            }

            else if (backward == 1)
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }

        else
        {
            return controls.Gameplay.Move.ReadValue<Vector2>().y;

        }
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
        if (!controller)
        {
            return Input.GetAxis("Crouch");
            /*if(controls.MKB.Jump.triggered)
            {
                return 1;
            }

            else
            {
                return 0;
            }*/
        }

        else
        {
            bool press = false;
            controls.Gameplay.Crouch.performed += ctx => press = ctx.canceled;

            if(press)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }
    }

    public override float getMouseX()
    {
        if (!controller)
        {
            return Input.GetAxis("Mouse X");
            //return controls.MKB.Rotate.ReadValue<Vector2>().x*Time.deltaTime;
        }

        else
        {
            return controls.Gameplay.Rotate.ReadValue<Vector2>().x;
        }
    }

    public override float getMouseY()
    {
        if (!controller)
        {
            return Input.GetAxis("Mouse Y");
            //return controls.MKB.Rotate.ReadValue<Vector2>().y*Time.deltaTime;
        }

        else
        {
            return controls.Gameplay.Rotate.ReadValue<Vector2>().y;
          //  controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
            //return rotate.y;
        }
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
