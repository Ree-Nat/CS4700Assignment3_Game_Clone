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
*purpose: This program controls the player input by using the inbuilt Unity Input System and rigid body physics. 
*
****************************************************************/

using UnityEngine;
using System.Numerics;

public class CameraController : MonoBehaviour
{

    private Camera camera;
    private RaycastHit2D center;
    private Vector2 centerPoint; 
    private GameObject player;
    
    private Vector2 playerOrigin;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 centerPoint = getCameraCenterPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if playerHitCenterPoint()
        {
            BegintrackObject() // make camera transfrom x == player transform-x
        }
        else if playerHitBeginningPoint()
        {
            delockTracking() //line shifts left to delock camera from object
        }

    }

    private void getCenterCenterPoint()
    {
        float x_center = camera.ViewportPointToRay
    }
}
