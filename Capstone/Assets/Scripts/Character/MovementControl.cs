﻿using System.Collections;
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

    float rotX;
    float rotY;

    public Camera eyes;
    public float jumpVelo = 4f;
    float yVelo;

    private bool jumped, crouched;

    public float playerHeight = 2f;

    CharacterController cControl;
    public Animator animator;

    public AbstractCharacterInput characterInput;

    void Start()
    {
        if(cControl == null)
            cControl = gameObject.GetComponent<CharacterController>();
        if(animator == null)
            animator = gameObject.GetComponent<Animator>();
    }
    public MovementControl(GameObject gameObject, Camera eyes)
    {        
        cControl = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();

        crouched = false;
        jumped = false;
        cControl.height = playerHeight;
        this.eyes = eyes;
    }

    public void control()
    {
        movement();
        crouch();
        gravity();

        if(characterInput.getJumpInput())
        {
            jump();
        }
    }

    void movement()
    {
        if (cControl.isGrounded)
        {
            if (!stop)
            {
                speedX += characterInput.getHorizontalInput() * speed * Time.deltaTime;
                speedZ += characterInput.getVerticalInput() * speed * Time.deltaTime;
                speedX = speedX * Mathf.Abs(characterInput.getHorizontalInput());
                speedZ = speedZ * Mathf.Abs(characterInput.getVerticalInput());
            }
        }
        else
        {
            speedX += characterInput.getHorizontalInput() * airSpeed;
            speedZ += characterInput.getVerticalInput() * airSpeed;
        }


        if (speedX > maxSpeed)
        {
            speedX = maxSpeed;
        }
        else if (speedX < -maxSpeed)
        {
            speedX = -1 * maxSpeed;
        }

        if (speedZ > maxSpeed)
        {
            speedZ = maxSpeed;
        }
        else if (speedZ < -1 * maxSpeed)
        {
            speedZ = -1 * maxSpeed;
        }

        rotX = characterInput.getMouseX() * sens;
        rotY = characterInput.getMouseY() * sens;

        Vector3 move = new Vector3(speedX, yVelo, speedZ);

        gameObject.transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);
        move = gameObject.transform.rotation * move;

        cControl.Move(move * Time.deltaTime);

        if (Mathf.Abs(cControl.velocity.magnitude) < 0.05f)
            animator.SetInteger("Condition", 0);
        else
            animator.SetInteger("Condition", 2);

    }

    void jump()
    {
        if (cControl.isGrounded && !stop)
        {
            jumped = true;
            yVelo = jumpVelo;
        }
    }

    void gravity()
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

    void crouch()
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
}
