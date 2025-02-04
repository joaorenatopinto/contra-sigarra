﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float enemySpeed = 0.2f;
    Vector2 rayLine;
    // Start is called before the first frame update
    void Start()
    {
        rayLine = Vector2.right + Vector2.down;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
          
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayLine, 1);
        if (hit.collider == null)
        {
            
            rayLine.x = -rayLine.x;
            enemySpeed = -enemySpeed;
            transform.Rotate(0f, 180f, 0f);

        }

        transform.position = new Vector2(transform.position.x + this.enemySpeed * Time.fixedDeltaTime, transform.position.y);


    }
}
    