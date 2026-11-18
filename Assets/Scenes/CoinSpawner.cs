using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinPrefabs; 
    
    public float minX = -50f;
    public float maxX = 50f;
    public float minY = -50f;
    public float maxY = 50f;
    
    public int coinsPerBatch = 5;

    void Start()
    {
        SpawnCoins();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            SpawnCoins();
        }
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinsPerBatch; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            int randomIndex = Random.Range(0, coinPrefabs.Length);
            
            Instantiate(coinPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}