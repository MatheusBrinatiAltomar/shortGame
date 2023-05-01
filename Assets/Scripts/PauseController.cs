using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Player player;
    public static bool gameIsPaused;
    public bool gameEnd;
    public GameObject gamePausePanel;
    public Text youWinText;

    void Start() {
        gameEnd = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame() {
        Time.timeScale = gameIsPaused ? 0f : 1f;
        gamePausePanel.SetActive(gameIsPaused ? true : false);
    }

    public void Reset() {
        player.Death(true);
        gameEnd = false;
        gameIsPaused = false;
        PauseGame();
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
