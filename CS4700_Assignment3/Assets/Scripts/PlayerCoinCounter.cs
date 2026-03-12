using UnityEngine;
/***************************************************************
*file: PlayerCoinCounter.cs
*author: T. Diaz
*class: CS 4700-1 Game Development
*assignment: program 3
*date last modified: 3/10/2026
*
*purpose: This program iterates the total coin amount and prints total to console when player collects coin.
****************************************************************/
public class PlayerCoinCounter : MonoBehaviour
{
    public int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }
}
