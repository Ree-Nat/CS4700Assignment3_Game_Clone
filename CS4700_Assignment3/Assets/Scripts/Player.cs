using UnityEngine;

/***************************************************************
*file: Player.cs
*author: Jacob Takaoka
*class: CS 4700-1 Game Development
*assignment: program 3
*date last modified: 3/12/2026
*
*purpose: This script modifies and gest the atributs of player with their lives and current power.
****************************************************************/

public class Player : MonoBehaviour { 
    public int _defaultLives;
    public int _lives;
    public PowerState _currentState;
    private PowerManager powerManager;



    private void Awake()
    {
    }
    private void Start()
    {
        powerManager = new PowerManager();
        this._defaultLives = 3;
        _currentState = PowerState.None;
    }

    public void decreaseLives()
    {
        _lives -= 1;
    }

    public GameObject getPlayerObject()
    {
        return gameObject;
    }

    public void resetLives()
    {
        _lives = _defaultLives;
    }

    public int getLives()
    {
        return this._lives;
    } 

    public void takeDamage()
    {
        if(_currentState != PowerState.None)
        {
            // powerManager.changePlayerPower(this, PowerState.None);

            setPower(PowerState.None);
        }
        else if(_lives == 0)
        {
            GameManager.gameManagerInstance.gameOver();
        }
        {
            decreaseLives();
        }

    }

    public void setPower(PowerState power)
    {
        powerManager.changePlayerPower(this, power);
        this._currentState = power;
    }

    public bool checkDead()
    {
        if( this._lives == 0)
         {
            return true;
        }
        return false;
    }

    public PowerState getPowerState()
    {
        return this._currentState;
    }

}
