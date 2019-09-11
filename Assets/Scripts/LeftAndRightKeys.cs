﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightKeys : MonoBehaviour
{
    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2 (60, 100);
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        var absVelX = Mathf.Abs(body2D.velocity.x);

        var forceX = 0f;
        var forceY = 0f;

        if(Input.GetKey("right")) {
            if(absVelX < maxVelocity.x){
                forceX = speed;
            } 
        } else if (Input.GetKey("left")){
                if(absVelX < maxVelocity.x){
                    forceX = -speed;
                }
            }

        body2D.AddForce(new Vector2(forceX, forceY));
        
    }
}
