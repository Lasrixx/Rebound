using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Color highScoreColour;
    public Color resetHighScoreColour;
    private int score = 0;

    void Start()
    {
        string previousHighScore = PlayerPrefs.GetInt("Highscore", 0).ToString();
        highScoreText.text = "Highscore: " + previousHighScore;
        highScoreColour = new Color(1f, 0.7524f, 0.0235f, 1f);
        resetHighScoreColour = new Color(0.2941f, 0.2941f, 0.2941f, 1f);
    }

    void Update()
    {
        scoreText.text = score.ToString("0");
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Highscore: " + score.ToString("0");
            highScoreText.color = highScoreColour;
        }
        if (Input.GetKey(KeyCode.X))
        {
            PlayerPrefs.SetInt("Highscore", 0);
            highScoreText.text = "Highscore: " + 0.ToString("0");
            highScoreText.color = resetHighScoreColour;
        }
    }

    public void UpdateScore()
    {
        score += 1;

    }
    public void CaughtStar()
    {
        score += 500;
    }
}
