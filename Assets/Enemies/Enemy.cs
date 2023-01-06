using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;


    public Transform player;


    public float speed;
    public float agroDistance;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        Debug.Log("Dist" + distToPlayer);

        if (distToPlayer > agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }

    private void StopHunting()
    {
        if (player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, -3);
        }
        else if (player.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, -3);
        }
        Debug.Log("yep");
    }

    private void StartHunting()
    {
        Debug.Log("nope");

        rb.velocity = new Vector2(0, -3);
    }
}
