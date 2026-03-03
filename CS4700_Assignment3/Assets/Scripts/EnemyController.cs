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

    
    public Collider2D enemy_hurtbox;
    public Collider2D enemy_hitbox ;

    public Collider2D playerHurtbox;
    public Collider2D playerHitBox;
    public float speed = 1.0f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    void moveLeft()
    {
        transform.position = transform.position - (new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    void OTriggerEnter2D(Collider2D collision)
    {
        print("now colliding");
    }
}
    
