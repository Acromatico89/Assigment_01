using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3.0f;
    private Rigidbody2D rb;
    
    private Player playerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
    }

    void FixedUpdate()
    {
        if (playerScript != null && playerScript.isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }
}