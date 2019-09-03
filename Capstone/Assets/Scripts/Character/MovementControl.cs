using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl: MonoBehaviour
{
    public bool stop = false;
    public float speed = 10f;
    public float airSpeed = 0.5f;
    public float sens = 1.1f;

    public float speedX;
    public float speedZ;
    public float maxSpeed = 7.5f;

    private float rotX;
    private float rotY;

    public Camera playerCamera;
    public float jumpVelo = 4f;
    private float yVelo;

    private bool jumped, crouched;

    public float playerHeight = 2f;

    private CharacterController cControl;
    public Animator animator;

    private AbstractCharacterInput characterInput;

    void Start()
    {
        if(cControl == null)
            cControl = gameObject.GetComponent<CharacterController>();
        if(animator == null)
            animator = gameObject.GetComponent<Animator>();
    }
    
    public MovementControl(GameObject gameObject, Camera playerCamera)
    {        
        cControl = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();

        crouched = false;
        jumped = false;
        cControl.height = playerHeight;
        this.playerCamera = playerCamera;
    }

    public void control()
    {
        movement();
        crouch();
        gravity();

        if(characterInput.getJump())
        {
            jump();
        }
    }

    private void movement()
    {
        if (cControl.isGrounded)
        {
            if (!stop)
            {
                speedX += characterInput.getHorizontalInput() * speed * Time.deltaTime;
                speedZ += characterInput.getVerticalInput() * speed * Time.deltaTime;
                speedX *= Mathf.Abs(characterInput.getHorizontalInput());
                speedZ *= Mathf.Abs(characterInput.getVerticalInput());
            }
        }
        else
        {
            speedX += characterInput.getHorizontalInput() * airSpeed;
            speedZ += characterInput.getVerticalInput() * airSpeed;
        }

        speedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);
        speedZ = Mathf.Clamp(speedZ, -maxSpeed, maxSpeed);

        rotX = characterInput.getMouseX() * sens;
        rotY = characterInput.getMouseY() * sens;

        Vector3 move = new Vector3(speedX, yVelo, speedZ);

        gameObject.transform.Rotate(0, rotX, 0);
        playerCamera.transform.Rotate(-rotY, 0, 0);
        move = gameObject.transform.rotation * move;

        cControl.Move(move * Time.deltaTime);

        

    }

    private void jump()
    {
        if (cControl.isGrounded && !stop)
        {
            jumped = true;
            yVelo = jumpVelo;
        }
    }

    private void gravity()
    {

        if (cControl.isGrounded && jumped)
        {
            jumped = false;
            yVelo = Physics.gravity.y;
        }
        else
        {
            yVelo += Physics.gravity.y * Time.deltaTime;
        }
    }

    private void crouch()
    {
        if (!crouched && Input.GetButtonDown("Crouch"))
        {
            crouched = true;
            cControl.height = playerHeight / 2;
        }
        else if (Input.GetButtonDown("Crouch"))
        {
            crouched = false;
            cControl.height = playerHeight;
        }
    }

    public void setValues(Camera playerCamera, AbstractCharacterInput input)
    {
        this.playerCamera = playerCamera;
        this.characterInput = input;
    }
}
