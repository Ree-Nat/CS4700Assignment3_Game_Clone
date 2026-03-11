using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


/***************************************************************
*file: DoubleIt.cs
*author: Nathan Rinon, Jackob Takaoka
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/3/2026
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

    //Jump variables
    public bool grounded;
    public float jumpSpeed = 1f; 
    public float groundDetectionRayLength = 0.1f;
    public float holdTime = 0f;
    public float maxHoldTime = 0.06f;
    public float descentGravityScale = 5f;
    public float jumpHoldForce = 2f;
    private float normalGravityScale = 1f;
    public bool jumpReleased = false;
    public bool isJumping = false;
    RaycastHit2D groundHit;
    [SerializeField] private LayerMask groundLayer;


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

        

        if (moveAction.IsPressed() && sprintAction.IsPressed() )
        {
            {
                player_rigidbody.AddForce(moveValue * sprint_acceleration, ForceMode2D.Force);
                if (Mathf.Abs(player_rigidbody.linearVelocityX) > player_maxSpeed)
                {
                    //add opposing force to deal with constant acceleration
                    print("reached max sprinting speed");
                    player_rigidbody.AddForce(-player_rigidbody.linearVelocity.normalized * sprint_acceleration, ForceMode2D.Force);
                }
            }
        }

        else if (moveAction.IsPressed())
        {
            player_rigidbody.AddForce(moveValue * acceleration, ForceMode2D.Force);

            if (Mathf.Abs(player_rigidbody.linearVelocityX) > player_speed)
            {
                //add opposing force to deal with constant acceleration
                player_rigidbody.AddForce(-player_rigidbody.linearVelocity.normalized * acceleration, ForceMode2D.Force);
            }
        }

        grounded = isGrounded();
        JumpChecks();
        if (jumpAction.IsPressed())
        {
           
            HandleJump();
        }
        /*
        if(player_rigidbody.linearVelocityY < 0 && !grounded)
        {
            player_rigidbody.gravityScale = descentGravityScale;
        }
        */
    }


    private void HandleJump()
    {
        
        if (grounded)
         {

            player_rigidbody.gravityScale = normalGravityScale;
            player_rigidbody.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            grounded = false;
            isJumping = true;
        }
        else
        {
            isJumping = false;
            holdTime = 0f;
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

    public Rigidbody2D GetRigidbody2D()
    {
        return this.player_rigidbody;
    }


    //Purpose: Checks to see if jump conditions are met in order to help with logical conditions 
    //in the update class.
    private void JumpChecks()
    {
        if(jumpAction.IsPressed())
        {
            jumpReleased = false;
            holdTime += Time.fixedDeltaTime;
        }

        if (jumpAction.WasReleasedThisFrame())
        {
            jumpReleased = true;
            holdTime = 0f;

            // Cut jump short if still going up
        if (player_rigidbody.linearVelocityY > 0f)
            player_rigidbody.linearVelocity = new Vector2(
            player_rigidbody.linearVelocityX,
            player_rigidbody.linearVelocityY * 0.5f  // try 0.3–0.6
        );
        }

    }



    #region Collision Checks

    //Checks to see if player is grounded in order to ensure player does not double jump
    private bool isGrounded()
    {
        Vector2 boxCastOrigin = new Vector2(player_feetColl.bounds.center.x, player_feetColl.bounds.min.y);
        Vector2 boxCastSize = new Vector2(player_feetColl.bounds.size.x, groundDetectionRayLength);

        groundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, groundDetectionRayLength, groundLayer);
        if(groundHit)
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