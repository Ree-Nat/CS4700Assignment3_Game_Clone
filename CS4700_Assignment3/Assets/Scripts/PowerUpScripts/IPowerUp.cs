using Unity.VisualScripting;
using UnityEngine;
/***************************************************************
*file: IPowerUp.cs
*author: Nathan Rinon
*class: CS 4700 - Game Development
*assignment: program 3
*date last modified: 3/12/2026
*
*purpose: This script is an interface to ensure all powerup has the funcion ApplyPowerUp for consitancy
****************************************************************/

public interface IPowerUp
{
    public abstract PowerState ApplyPowerUp(Player player);

}