using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public TextMeshProUGUI HighScoreText;
    private int score = 0;

    void Awake()
    {
        scoreText.text = score.ToString();
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    void Update()
    {
        score = (int)(player.transform.position.x - player.startingPosition.x);
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
            HighScoreText.text = "High Score: " + score.ToString();
        }
        scoreText.text = "Score: " + score;
    }
}
