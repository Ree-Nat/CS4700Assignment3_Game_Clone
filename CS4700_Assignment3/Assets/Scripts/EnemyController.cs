using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/***************************************************************
*file: DoubleIt.cs
*author: Nathan
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/11/2026
*
*purpose: This program controls enemy's behavior and movment 
*
****************************************************************/

public class EnemyController : MonoBehaviour
{
    
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private bool hasSecondPhase;
    [SerializeField] private GameObject secondPhaseAsset;
    [SerializeField] private float knockBack = 5.0f;
    [SerializeField] private Rigidbody2D player_rigidBody;
    private Rigidbody2D enemy_rigidBody;
    private bool hasSpawned = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_rigidBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        enemy_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    //Move goomba the the left side of the screen
    void moveLeft()
    {
        //transform.position = transform.position - (new Vector3(speed, 0, 0) * Time.deltaTime);
        //enemy_rigidBody.AddForce(new Vector2 (0, 0));

        enemy_rigidBody.linearVelocity = new Vector2(-speed, enemy_rigidBody.linearVelocityY);
    }
    //Move goomba the the right side of the screen
    void moveRight()
    {
        enemy_rigidBody.linearVelocity = new Vector2(speed, enemy_rigidBody.linearVelocityY);
    }
         
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject other = collision.gameObject;

        if(collision.gameObject.name == "PlayerHitBox" && 
           hasSecondPhase == false)
        {
            destroySelf();
            addUpwardForce(player_rigidBody);
        }
        else if(collision.gameObject.name == "PlayerHitBox"
        && hasSecondPhase == true)
        {

            //logic to defend against duplicate spawn
            if(hasSpawned == true) return; 
            hasSpawned = true;

            Destroy(gameObject);  
            addUpwardForce(player_rigidBody);
            Instantiate(secondPhaseAsset, transform.position, Quaternion.identity);
        }

        if(collision.gameObject.name == "PlayerHurtBox")
        {
            other.GetComponentInParent<Player>().takeDamage();
        }

    }

    private void addUpwardForce(Rigidbody2D player_rigidBody)
    {
        player_rigidBody.AddForce(Vector2.up * knockBack, ForceMode2D.Impulse);
    }


    private void destroySelf()
    {
        GameObject.Destroy(gameObject); 
    }
}
    
