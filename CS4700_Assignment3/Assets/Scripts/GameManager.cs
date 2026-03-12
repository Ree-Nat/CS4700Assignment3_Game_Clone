using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/***************************************************************
*file: PlayerCoinCounter.cs
*author: Jacob Takaoka
*class: CS 4700-1 Game Development
*assignment: program 3
*date last modified: 3/12/2026
*
*purpose: This script manages the current game runtime, managing switching scenes and end game condition as a singleton.
****************************************************************/



public class GameManager : MonoBehaviour
{

    TimerController timerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public static GameManager gameManagerInstance;
    private int playerCoins;
    private bool gameEnded { get; set; }
    
    //Purpose: reinforce singleton pattern
    private void Awake()
    {
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManagerInstance = this;
        }

    }

    void Start()
    {
        

            DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //Purpose-> Executs game over and resets the scene
    public void gameOver()
    {
        print("Game Over!");
        this.resetLevel();
    }

    public void resetLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
