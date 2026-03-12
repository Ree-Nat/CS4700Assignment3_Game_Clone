using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Unity.Collections;
using Vector3 = UnityEngine.Vector3;



/***************************************************************
*file: Camera Controller.cs
*author: Nathan Rinon
*class: CS 4700-1 Game Development
*assignment: program 1
*date last modified: 3/2/2026
*
*purpose: This program controls the player camera by checking if the player
* is colliding with a center raycast bassed on the camera's center 
* If the player hits the beginning raycast from the beginning level, it resets
* to the original time the ray was when the scene is loaded. 
****************************************************************/




public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Collider2D trackingCollider;
    public int rayCastLength;
    public float startVector_XOffset;
    public float startVector_YOffset;
    [SerializeField] private LayerMask playerLayer;
    private RaycastHit2D beginningRay;
    private Vector2 gameStartVector;
    private Vector2 offest;
    bool cameraLock; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //offsetts the ray so middle vector and beginning vector do not overlap
        gameStartVector = new Vector2(transform.position.x, transform.position.y) + new Vector2(startVector_XOffset, startVector_YOffset);
        cameraLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        beginningRay = Physics2D.Raycast(gameStartVector, Vector2.up, Mathf.Infinity, playerLayer);
        Debug.DrawRay(gameStartVector, Vector2.up);
        if(beginningRay.collider)
        {
            cameraLock = false;
        }
        if (cameraLock == true) {
            transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);
        }
        else if (cameraLock == false && playerHitCenterPoint() == true)
        {
            cameraLock = true;
            transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);
        }
       
    }

    // Purpose get the Camera vector center point in order to draw raycast
    
    private bool playerHitCenterPoint()
    {
        if (player.transform.position.x >= transform.position.x)
            return true; 
        return false;
    }


    private Vector2 getCameraCenterPoint()
    {
        float x_center = transform.position.x;
        return new Vector2(x_center, 0);

    }

    //Purpose get the player starting x point to draw a ray 
    private Vector2 getPlayerXPos()
    {
        float player_x = player.transform.position.x;
        return new Vector2(player_x, 0);

    }

 }

