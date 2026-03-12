using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;



/***************************************************************
*file: DoubleIt.cs
*author: Nathan Rinon
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/3/2026
*
*purpose: This script controls the shell object by using linear algebra dot product and referencing colliders. 
*
****************************************************************/

public class ShellController : MonoBehaviour
{

    private Rigidbody2D _player_rb;
    [SerializeField] private Collider2D _shell_hitbox;
    [SerializeField] private Collider2D _shell_hurtbox;
    private Rigidbody2D _shell_rb;
    [SerializeField] private Player player;
    [SerializeField] private float knockBack = 5.0f;
    [SerializeField] private float speed = 5.0f;
    private Vector2 _shell_direction;

    private Collider2D _boxCollider;

    private bool isHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _player_rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        _shell_rb = GetComponent<Rigidbody2D>();
        isHit = false;
        _shell_hitbox.enabled = false;
        _shell_direction = Vector2.zero;
        _boxCollider = GetComponent<Collider2D>();
        freezeShell(_shell_rb);
    }

    void Update()
    {
        //_shell_rb.AddForce(_shell_direction * speed, ForceMode2D.Force);
        _shell_rb.linearVelocity = new Vector2(_shell_direction.x * speed, _shell_rb.linearVelocity.y);
    }

    //Gets the direction of shell when hit by player using dot product math
    private Vector2 getHitDirection(Collision2D collider)
    {
        Vector2 ContactPoint = collider.contacts[0].normal;
        Vector2 leftVector = Vector2.left;
            float dotResult = Vector2.Dot(ContactPoint, leftVector);
            if(dotResult < 0)
            {
                return Vector2.right;
            }
            else
            {
               return Vector2.left;
            }

    }

    //Goes left when shell is hit on the right side
    private void goLeft(Rigidbody2D rb)
    {
        rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
    }

    //Goes right when shell is hit on the right side
    private void goRight(Rigidbody2D rb){
    
        rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
    }

    //Purpose: Freezes shell by setting velocity to 0
    private void freezeShell(Rigidbody2D rb){
        rb.linearVelocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "PlayerHurtBox" && isHit == true)
        {
            player.takeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.otherCollider == _boxCollider) return;

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else if(isHit==false && collision.gameObject.name == "Player"){
            
            _player_rb.AddForce(Vector2.up * knockBack, ForceMode2D.Impulse);
            _shell_direction = getHitDirection(collision);
            _shell_hitbox.enabled = true;
            isHit = true;
        }
        else if(isHit==true && collision.gameObject.name == "Player")
        {
            _player_rb.AddForce(Vector2.up * knockBack, ForceMode2D.Impulse);
            freezeShell(_shell_rb);
            isHit = false;
            _shell_hitbox.enabled = false;
            _shell_direction = Vector2.zero;
        }
        else if(getHitDirection(collision) == Vector2.left 
        || getHitDirection(collision) == Vector2.right)
        {
            freezeShell(_shell_rb);
            _shell_direction = getHitDirection(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3) //If destructable layer
        {
            Destroy(collision.gameObject);
        }
    }

}    
