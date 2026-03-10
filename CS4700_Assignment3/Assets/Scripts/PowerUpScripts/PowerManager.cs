using System;
using System.Diagnostics;
using UnityEngine.UIElements;


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
