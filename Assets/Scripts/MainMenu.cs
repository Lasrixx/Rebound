using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public TransitionsManager transitionsManager;
    public Text highScoreText;

    private void Start()
    {
        string previousHighScore = PlayerPrefs.GetInt("Highscore", 0).ToString();
        highScoreText.text = "Highscore: " + previousHighScore;
    }


    public void PlayGame()
    {
        transitionsManager.LoadLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads next level in build settings 
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
