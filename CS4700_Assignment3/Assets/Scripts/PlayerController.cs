using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


/***************************************************************
*file: DoubleIt.cs
*author: T. Diaz
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/20/2112
*
*purpose: This program controls the player input by using the inbuilt Unity Input System and rigid body physics. 
*
****************************************************************/
public class PlayerController : MonoBehaviour

{
    //Input listeners
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private Vector2 moveValue;
    private Vector2 jumpValue;



    //Collider properties 
    private Rigidbody2D player_rigidbody;
    private BoxCollider2D player_collider;
    [SerializeField] private BoxCollider2D player_feetColl;


    //Variables to store player walk
    public float player_speed = 8;
    public float player_maxSpeed = 14;
    public float acceleration = 10f;
    public float sprint_acceleration = 10f;
    private float player_linearVelocity;

    //Jump variables
    public bool grounded;
    public float jumpSpeed = 3f; 
    public float groundDetectionRayLength = 1f;
    public float holdTime = 0f;
    public float maxHoldTime = 3f;
    public float descentGravityScale = 2f;
    private float normalGravityScale = 1f;
    private bool jumpReleased = false;
    private bool reachedApex = false;
    private bool isJumping = false;
    RaycastHit2D groundHit;


    // Purpose : Enables action map if object is destroyed or disabled
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    // Purpose : Removes action map if object is destroyed or disabled
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }


    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        player_rigidbody = GetComponent<Rigidbody2D>();
        player_collider = GetComponent<BoxCollider2D>();


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        moveValue = moveAction.ReadValue<Vector2>();

        if (jumpAction.IsPressed())
        {
           
            handleJump();
        }

        if (moveAction.IsPressed() && sprintAction.IsPressed() && moveValue != Vector2.zero)
        {
            {
                player_rigidbody.AddForce(moveValue * sprint_acceleration, ForceMode2D.Force);
                if (player_rigidbody.linearVelocity.magnitude > player_maxSpeed)
                {
                    //add opposing force to deal with constant acceleration
                    print("reached max sprinting speed");
                    player_rigidbody.AddForce(-moveValue * sprint_acceleration, ForceMode2D.Force);
                }
            }
        }

        else if (moveAction.IsPressed() && moveValue != Vector2.zero)
        {
            player_rigidbody.AddForce(moveValue * acceleration, ForceMode2D.Force);

            if (player_rigidbody.linearVelocity.magnitude > player_speed)
            {
                //add opposing force to deal with constant acceleration
                player_rigidbody.AddForce(-moveValue * acceleration, ForceMode2D.Force);
            }
        }
    }

    private void handleJump()
    {
        grounded = isGrounded();
        JumpChecks();
        if(grounded && player_rigidbody.linearVelocityY >= 0)
         {
            player_rigidbody.gravityScale = normalGravityScale;
            player_rigidbody.linearVelocity = new Vector2(player_rigidbody.linearVelocity.x, jumpSpeed);
            grounded= false;
            isJumping = true;
         }
        else if(!grounded && checkJumpDuration() && isJumping)
        {
            player_rigidbody.linearVelocity += new Vector2(0, jumpSpeed);
        }
        else if (player_rigidbody.linearVelocityY < 0  || jumpReleased)
        {
            player_rigidbody.gravityScale = descentGravityScale;
        }

        if (grounded)
        {
            holdTime = 0f;
            isJumping = false;
            player_rigidbody.gravityScale = normalGravityScale;
        }

    }

    //Purpose: Checks to see if holding down button duration is reached
    private bool checkJumpDuration()
    {
        if(holdTime < maxHoldTime)
        {
            return true;
        }
        else
        {
            return false;
        }


    }

    private void JumpChecks()
    {
        if(jumpAction.IsPressed())
        {
            jumpReleased = false;
            holdTime += Time.deltaTime;
        }

        if(jumpAction.WasReleasedThisFrame())
        {
            jumpReleased = true;
            holdTime = 0f;
        }

    }



    #region Collision Checks

    private bool isGrounded()
    {
        Vector2 boxCastOrigin = new Vector2(player_feetColl.bounds.center.x, player_feetColl.bounds.min.y);
        Vector2 boxCastSize = new Vector2(player_feetColl.bounds.size.x, groundDetectionRayLength);

        groundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, groundDetectionRayLength);
        if(groundHit.collider)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

}