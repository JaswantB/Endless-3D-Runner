using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;
    public float scoreRate = 10f; // How many points per second
    private PlayerMovement playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
        score = 0f;
    }

    void Update()
    {
        if (!playerController.gameOver)
        {
            score += Time.deltaTime * scoreRate;
            scoreText.text =  Mathf.FloorToInt(score).ToString();
        }
    }
}
