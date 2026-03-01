using UnityEngine;
using UnityEngine.InputSystem;

/***************************************************************
*file: DoubleIt.cs
*author: T. Diaz
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/20/2112
*
*purpose: This program controls the player input by using the inbuilt Unity Input System. 
*
****************************************************************/
public class PlayerController : MonoBehaviour

{
    public InputActionAsset InputActions;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    private Vector2 moveValue;
    private Vector2 jumpValue;

    private Rigidbody2D player_rigidbody;

    public float player_speed = 10;
    public float player_maxSpeed = 15;
    public float player_jumpSpeed = 10;
    public float player_maxJumpSpeed = 15;
    public float player_linearVelocity; 

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
        player_linearVelocity = player_rigidbody.linearVelocityX;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        jumpValue = moveAction.ReadValue<Vector2>();

        if (moveAction.IsPressed()) 
        {
            player_rigidbody.MovePosition(player_rigidbody.position + moveValue * player_speed * Time.deltaTime);
        }
        if(moveAction.IsPressed() && sprintAction.IsPressed() && player_rigidbody.linearVelocityX < player_maxSpeed)
        {
            print("Is sprinting");
            player_rigidbody.AddForceX(15 * moveValue.x);
        }
    }


    void sprintState()
    {
        
    }
}
