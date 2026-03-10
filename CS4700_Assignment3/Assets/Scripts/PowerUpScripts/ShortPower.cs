using Unity.VisualScripting;
using UnityEngine;


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