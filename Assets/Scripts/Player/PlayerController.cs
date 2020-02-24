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

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovementAndAnimationControl();
    }

    private void PlayerMovementAndAnimationControl()
    {
        moveDir = Vector3.zero;

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)
            && !Input.GetKeyDown(KeyCode.Mouse0))
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Idle);

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
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
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
            moveDir = new Vector3(0, 0, -PlayerSpeed);
            moveDir = transform.TransformDirection(moveDir);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
            moveDir = new Vector3(-PlayerSpeed, 0, 0);
            moveDir = transform.TransformDirection(moveDir);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Walk);
            moveDir = new Vector3(PlayerSpeed, 0, 0);
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayerAnimator.SetInteger("Movement", (int)CharacterMovement.Attack);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            moveDir += Vector3.up * JumpSpeed;
        }

        Rotation += Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;

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
