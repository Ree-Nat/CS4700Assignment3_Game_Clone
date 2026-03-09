using Unity.VisualScripting;
using UnityEngine;


public class ShortPower : PowerUp
{
	
	private int heightDivider = 2;
		
	public override void applyPowerUp(Player player)
	{
		Vector3 playerScale = player.gameObject.transform.localScale;
		playerScale = new Vector3(playerScale.x, playerScale.y / heightDivider, playerScale.z);
	}

}