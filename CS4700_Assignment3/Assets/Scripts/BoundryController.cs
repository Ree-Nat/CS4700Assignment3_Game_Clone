using UnityEngine;



/***************************************************************
*file: BoundryController.cs
*author: Nathan Rinon
*class: CS 4700-1 Game Development
*assignment: program 3
*date last modified: 3/12/2026
*
*purpose: This program controls the game boundry. If a player hits a boundry, it calls the 
*game manager singleton and resets the level.
****************************************************************/



public class BoundryController : MonoBehaviour
{

    private Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        player.takeDamage();
        GameManager.gameManagerInstance.resetLevel();
    }
}
