using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] float scoreAmount;
    public float pointPerSecond = 3f;

    private void Start()
    {
        scoreAmount = 0f;
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        scoreText.text = "Score: " + (int)scoreAmount;
        scoreAmount += pointPerSecond * Time.deltaTime;

        if (scoreAmount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)scoreAmount);
            highScoreText.text = "HighScore: " + (int)scoreAmount;
        }
    }
}
