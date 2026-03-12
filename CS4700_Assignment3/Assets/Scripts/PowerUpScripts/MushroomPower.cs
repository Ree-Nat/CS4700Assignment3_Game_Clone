using UnityEngine;


/***************************************************************
*file: ShortPower.cs
*author: Nathan Rinon
*class: CS 4700-1 Game Development
*assignment: program 1
*date last modified: 3/12/2026
*
*purpose: This program controls the Tall power condition. It sets the power by inheriting the PowerUp interface and takes a player
and transform its scale.
****************************************************************/


public class MushroomPower : IPowerUp
{

    private int heightMultiplier = 2;

    public PowerState ApplyPowerUp(Player player)
    {
        Transform t = player.gameObject.transform;
        t.localScale = new Vector3(t.localScale.x, t.localScale.y * heightMultiplier, t.localScale.z);
        return PowerState.Mushroom;
    }

}