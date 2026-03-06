using UnityEngine;

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
