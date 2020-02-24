using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 3.0f;
    public float RunSpeed = 10.0f;
    public float JumpSpeed = 100.0f;
    public float RotationSpeed = 500.0f;
    public float Rotation = 0.0f;
    public float Gravity = 8.0f;
    public bool isGrounded = true;

    Vector3 moveDir;

    CharacterController Controller;
    Animator PlayerAnimator;
    InputDevice InputDev;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        PlayerAnimator = GetComponent<Animator>();
        InputDev = InputDevice.GetInstance();
    }

    void Update()
    {
        PlayerMovementAndAnimationControl();
    }

    private void PlayerMovementAndAnimationControl()
    {
        moveDir = Vector3.zero;

        if (InputDev.IsIdle())
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Idle);

        if (InputDev.IsWalkForward())
        {
            if (InputDev.IsRun())
            {
                PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Run);
                moveDir = new Vector3(0, 0, RunSpeed);
            }
            else
            {
                PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
                moveDir = new Vector3(0, 0, PlayerSpeed);
            }    
            
            moveDir = transform.TransformDirection(moveDir);            
        }
        else if (InputDev.IsWalkBack())
        {
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
            moveDir = new Vector3(0, 0, -PlayerSpeed);
            moveDir = transform.TransformDirection(moveDir);
        }
        else if (InputDev.IsWalkLeft())
        {
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
            moveDir = new Vector3(-PlayerSpeed, 0, 0);
            moveDir = transform.TransformDirection(moveDir);
        }
        else if (InputDev.IsWalkRight())
        {
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
            moveDir = new Vector3(PlayerSpeed, 0, 0);
            moveDir = transform.TransformDirection(moveDir);
        }

        if (InputDev.IsAttak())
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Attack);

        if (InputDev.IsJump() && isGrounded)
        {
            isGrounded = false;
            moveDir += Vector3.up * JumpSpeed;
        }

        Rotation += InputDev.Rotation() * RotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, Rotation, 0);
        Controller.Move(moveDir * Time.deltaTime);
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    enum CharacterMovement
    {
        Walk = 1,
        Attack = 2,
        Run = 3,
        Idle = 4
    }
}
