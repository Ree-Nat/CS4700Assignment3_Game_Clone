using UnityEngine;
public class TimerController : MonoBehaviour
/***************************************************************
*file: DoubleIt.cs
*author: T. Diaz
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/2/2026
*
*purpose: This program controls the game timer. After checking if it is 0, sends a game over message to GameController object
*
****************************************************************/
{

    public float maxTime = 256;
    public float currentTime;
    private bool isEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = maxTime;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnded == false)
        {
            decreaseClock();
            checkIfEnded();
        }
    }

    //increase the clock for every frame
    public void decreaseClock()
    {
        currentTime = currentTime - Time.deltaTime; 
    }

    //Purpose: Checks to see if clock reach 0 to see if game ended
    public bool checkIfEnded()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;
            print("is ended");
            isEnded = true;
            return isEnded;
        }
        isEnded = false;
        return isEnded;
    }

    //Purpose: get the time in integer for display
    public int getTime()
    {
        return (int) Mathf.Round(currentTime);
    }

}
