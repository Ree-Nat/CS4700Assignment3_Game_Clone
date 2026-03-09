using Unity.VisualScripting;
using UnityEngine;

/***************************************************************
*file: DoubleIt.cs
*author: Nathan
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/3/2022
*
*purpose: This program controls enemy's behavior and movment 
*
****************************************************************/

public class EnemyController : MonoBehaviour
{
    
    public float speed = 1.0f;
    Rigidbody2D enemy_rigidBody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if(collision.gameObject.name == "PlayerHitBox")
        {
            destroySelf();
        }
        else if(collision.gameObject.name == "PlayerHurtBox")
        {
            damage(collision.gameObject);
        }

    }

    //DO stuff with gameObject
    private void damage(GameObject entity)
    {

    }

    private void destroySelf()
    {
        GameObject.Destroy(gameObject); 
    }
}
    
