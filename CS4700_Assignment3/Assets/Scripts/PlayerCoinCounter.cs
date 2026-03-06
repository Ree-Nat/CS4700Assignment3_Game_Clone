using UnityEngine;

public class PlayerCoinCounter : MonoBehaviour
{
    public int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }
}
