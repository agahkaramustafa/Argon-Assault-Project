using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
        scoreText.text = "Score: " + score.ToString();
    }
}
