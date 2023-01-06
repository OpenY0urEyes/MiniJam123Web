using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] bool moving;

    private Rigidbody2D rb;

    public Transform player;

    [SerializeField] 
    GameObject bullet;

    float fireRate;
    float nextFire;

    
    public float agroDistance;


    float speed = 1;

    [Header("moving x")]
    public float right;
    public float left;

    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }


    private void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        Debug.Log("Dist" + distToPlayer);

        if (distToPlayer < agroDistance)
        {
            Attack();

        }
        else
        {
            IdleFly();
            Debug.Log("idle");

        }
    }


    private void IdleFly()
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

    private void Attack()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }


}
