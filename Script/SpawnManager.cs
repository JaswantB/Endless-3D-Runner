using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  
   
    public float spawnTime = 2;
    public float spawnInterval = 1.5f;
    public GameObject [] obstaclePrefab;
    private PlayerMovement playerControllerScript;
    private float spawnRangeX = 35;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnObstacle",spawnTime,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPosition = new Vector3(spawnRangeX, 0, 0);
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacleIndex], spawnPosition, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }

}
