using Unity.VisualScripting;
using UnityEngine;

public interface IPowerUp
{
    public abstract PowerState ApplyPowerUp(Player player);

}