using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f;
    private PlayerMovement playerControllerScript;
    private float leftBound = -15f;

   
 
    void Start()
    {
        playerControllerScript=GameObject.Find("Player").GetComponent<PlayerMovement>();
        

    }

    // Update is called once per frame
    void Update()
    {

        SpawnObstacle();
   
       
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
