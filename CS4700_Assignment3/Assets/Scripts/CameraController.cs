using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;




/***************************************************************
*file: DoubleIt.cs
*author: T. Diaz
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/2/2026
*
*purpose: This program controls the player camera by checking if the player
* is colliding with a center raycast bassed on the camera's center 
* If the player hits the beginning raycast from the beginning level, it resets
* to the original time the ray was when the scene is loaded. 
****************************************************************/

using UnityEngine;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Unity.Collections;

public class CameraController : MonoBehaviour
{

    private GameObject camera;
    private RaycastHit2D centerRay;
    private RaycastHit2D beginningRay;
    private Vector2 centerPoint; 
    private GameObject player;
    
    private Vector2 playerOrigin;
    private Vector2 gameStartVector;

    public int rayCastLength; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 centerPoint = getCameraCenterPoint();
        Vector2 gameStartVector = getPlayerXPos();
        RaycastHit2D beginningRay = Physics2D.Raycast(gameStartVector, Vector2.up, Mathf.Infinity);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if playerHitCenterPoint()
        {
            BegintrackObject() // make camera transfrom x == player transform-x
        }
        else if playerHitBeginningPoint()
        {
            delockTracking() //line shifts left to delock camera from object
        }
        */
    }

    // Purpose get the Camera vector center point in order to draw raycast
    private Vector2 getCameraCenterPoint()
    {
        float x_center = camera.transform.position.x;
        return new Vector2(x_center, 0);

    }

    //Purpose get the player starting x point to draw a ray 
    private Vector2 getPlayerXPos()
    {
        float player_x = player.transform.position.x;
        return new Vector2(player_x, 0);

    }

    private Vector2 getPlayerXYPos()
    {
        float player_x = player.transform.position.x;
        float player_y = player.transform.position.y;
        return new Vector2(player_x, player_y);

    }
}
