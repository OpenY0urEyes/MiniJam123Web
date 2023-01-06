using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] bool moving;


    [SerializeField] bool x = false;
    [SerializeField] bool y = false;

    float speed = 1;

    [Header("moving x")]
    public float right;
    public float left;

    [Header("moving y")]
    public float up;
    public float down;



    private void FixedUpdate()
    {
        if (x)
        {
            if (transform.position.x > right)
            {
                moving = false;
            }
            if (transform.position.x < -left)
            {
                moving = true;
            }

            if (moving)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            if (!moving)
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        }

        if (y)
        {
            if (transform.position.y > up)
            {
                moving = false;
            }
            if (transform.position.y < -down)
            {
                moving = true;
            }

            if (moving)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            }
            if (!moving)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            }
        }
        
    }
}
