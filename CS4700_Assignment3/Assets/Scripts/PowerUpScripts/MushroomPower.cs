using UnityEngine;


public class MushroomPower : PowerUp
{

    private int heightMultiplier = 2;

    public override void applyPowerUp(Player player)
    {
        Vector3 playerScale = player.gameObject.transform.localScale;
        playerScale = new Vector3(playerScale.x, playerScale.y * heightMultiplier, playerScale.z);
    }
    
}