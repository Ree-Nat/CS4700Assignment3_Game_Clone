using UnityEngine;


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