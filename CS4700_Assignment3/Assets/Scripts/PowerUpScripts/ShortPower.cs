using Unity.VisualScripting;
using UnityEngine;
/***************************************************************
*file: ShortPower.cs
*author: Nathan Rinon
*class: CS 4700-1 Game Development
*assignment: program 1
*date last modified: 3/12/2026
*
*purpose: This program controls the short power condition. It sets the power by inheriting the PowerUp interface and takes a player
and transform its scale.
****************************************************************/


public class ShortPower : IPowerUp
{
	
	private int heightDivider = 2;
		
	public PowerState ApplyPowerUp(Player player)
	{
        Transform t = player.gameObject.transform;
        t.localScale = new Vector3(t.localScale.x, t.localScale.y / heightDivider, t.localScale.z);
        return PowerState.Mushroom;
    }

}