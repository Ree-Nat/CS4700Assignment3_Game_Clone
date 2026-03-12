using System;
using System.Diagnostics;
using UnityEngine.UIElements;

/***************************************************************
*file: PowerManager.cs
*author: Nathan Rinon
*class: CS 4700-1 Game Development
*assignment: program 1
*date last modified: 3/12/2026
*
*purpose: This program creates a state manager by instantiating a PowerState enum and an IPower interface to control logic. 
*
****************************************************************/
public class PowerManager
{
    private IPowerUp selectedPower;
    private PowerState powerState;

    public PowerManager()
    {
        this.selectedPower = new ShortPower();
    }

    public void changePlayerPower(Player player, PowerState powerState)
    {
        switch (powerState)
        {
            case PowerState.None:
                powerState = PowerState.None;
                selectedPower = new ShortPower();
                break;
            case PowerState.Mushroom:
                selectedPower = new MushroomPower();
                break;
        }
        selectedPower.ApplyPowerUp(player);
    }

    public PowerState getCurrentSelectedPowerState()
    {
        return powerState;
    }
}
