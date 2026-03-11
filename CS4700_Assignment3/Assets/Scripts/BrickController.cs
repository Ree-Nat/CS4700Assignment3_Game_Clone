using System;
using NUnit.Framework;
using UnityEngine;


/***************************************************************
*file: DoubleIt.cs
*author: T. Diaz
*class: CS 4700 ? Game Development
*assignment: program 1
*date last modified: 3/11/2026
*
*purpose: This program controls the brick asset. When a player hits the bottom block, it breaks.
****************************************************************/

public class BrickController : MonoBehaviour
{

    
    private bool _powerUpUsed;
    [SerializeField] private bool _hasPowerUp;
    
    [SerializeField] private Sprite _usedBlockSprite;

    [SerializeField] private GameObject _powerUp;
    private SpriteRenderer _spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //purpose, spawn powerup by taking the position of the brick and 
    //adding 1. 
    private void spawnPowerUp(GameObject powerEntity)
    {
        Vector3 brickPos = transform.position;
        Vector3 spawnPos = brickPos + Vector3.up;
        Instantiate(powerEntity, spawnPos, Quaternion.identity);
    }
        
    //Breaks when player hurtbox hit object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "playerHeadBox" && _hasPowerUp == false
        && _spriteRenderer.sprite != _usedBlockSprite)
        {
            GameObject.Destroy(gameObject);
        }
        else if(collision.gameObject.name == "playerHeadBox" && _hasPowerUp == true)
        {
            _spriteRenderer.sprite = _usedBlockSprite;
            spawnPowerUp(_powerUp);
            _hasPowerUp = false;
        }

       
    }
}
