using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    public int score = 0;
    public int targetScore = 1000;
    public bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGameOver) return;

        var wValue = Keyboard.current.wKey.value;
        gameObject.transform.position += (Vector3)(wValue * Vector2.up * speed * Time.deltaTime);

        var aValue = Keyboard.current.aKey.value;
        gameObject.transform.position += (Vector3)(aValue * Vector2.left * speed * Time.deltaTime);

        var sValue = Keyboard.current.sKey.value;
        gameObject.transform.position += (Vector3)(sValue * Vector2.down * speed * Time.deltaTime);

        var dValue = Keyboard.current.dKey.value;
        gameObject.transform.position += (Vector3)(dValue * Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGameOver) return;

        if (other.CompareTag("Coin"))
        {
            Coin coinScript = other.GetComponent<Coin>();
            if (coinScript != null)
            {
                score += coinScript.scoreValue;
                Debug.Log("Current Score: " + score);

                if (score >= targetScore)
                {
                    Debug.Log("you won");
                    isGameOver = true;
                }
            }
            
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("you lose");
            isGameOver = true;
        }
    }
}