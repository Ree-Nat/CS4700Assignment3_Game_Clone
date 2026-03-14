using UnityEngine;
using TMPro;
using Unity.VisualScripting;

/***************************************************************
*file: GameHUD.cs
*author: Jacob Takaoka
*class: CS 4700-1 Game Development
*assignment: program 3
*date last modified: 3/14/2026
*
*purpose: This program updates the UI according to the time and coins collected by the player.
****************************************************************/

public class GameHUD : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timerText;
    [SerializeField] private Timer timer;

    public int coins = 0;
    public float levelTime = 300f;

    void Start()
    {
        UpdateCoinUI(coins);
        UpdateTimerUI();
    }

    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (levelTime < 0)
        {
           GameManager.gameManagerInstance.gameOver();
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinUI(coins);
    }

    public void UpdateCoinUI(int coins)
    {
        coinText.text = "x" + coins.ToString("D2");
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.CeilToInt(levelTime).ToString();
    }
}