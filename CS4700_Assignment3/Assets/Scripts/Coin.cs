using UnityEngine;

/***************************************************************
*file: Coin.cs
*author: T. Diaz
*class: CS 4700 - Game Development
*assignment: program 3
*date last modified: 3/10/2026
*
*purpose: This program controls the coin object where the player coin count goes up and the object is destroyed
*when player comes into contact with object.
****************************************************************/

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCoinCounter counter = other.GetComponent<PlayerCoinCounter>();

            if (counter != null)
                counter.AddCoins(value);

            Destroy(gameObject);
        }
    }
}
