using UnityEngine;


/***************************************************************
*file: DoubleIt.cs
*author: T. Diaz
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/2/2026
*
*purpose: This program controls the brick asset. When a player hits the bottom block, it breaks.
****************************************************************/

public class BrickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    //Breaks when player hurtbox hit object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "playerHeadBox")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
