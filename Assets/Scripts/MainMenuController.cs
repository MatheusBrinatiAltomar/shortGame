using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuObject;
    public GameObject howToPlayMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuObject.SetActive(true);
        howToPlayMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        EditorSceneManager.LoadScene("Game");
    }

    public void HowToPlayMenu()
    {
        mainMenuObject.SetActive(false);
        howToPlayMenuObject.SetActive(true);
    }

    public void Back()
    {
        mainMenuObject.SetActive(true);
        howToPlayMenuObject.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
