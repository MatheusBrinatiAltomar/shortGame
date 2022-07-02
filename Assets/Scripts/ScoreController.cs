using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Player player;
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Score: " + (int) (player.transform.position.x - player.startingPosition.x);
    }
}
