using UnityEngine;



public class Player : MonoBehaviour 
{
    public int _defaultLives;
    public int _lives;
    public PowerState _currentState;

    private void Start()
    {
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
           _currentState = PowerState.None;
        }
        else
        {
            decreaseLives();
        }
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

    public void setPowerState(PowerState powerState)
    {
        this._currentState = powerState;
    }
}
