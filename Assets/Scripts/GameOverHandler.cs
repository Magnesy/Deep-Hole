using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text highestScoreText;
    [SerializeField] private GameObject gameOverDisplay;

    public const string LevelKey = "Level";
    public const string LastLevelKey = "LastLevel";


    
    public void EndGame()
    {
        //asteroidSpawner.enabled = false;

        //gameOverText.text = "Your Score : " + finalScore;

        gameOverDisplay.gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        int level = PlayerPrefs.GetInt(LevelKey, 1);
        level = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt(LevelKey , level);
        int lastLevel = PlayerPrefs.GetInt(LastLevelKey, 1);
        if(level > lastLevel) {PlayerPrefs.SetInt(LastLevelKey , level);}
        SceneManager.LoadScene(level);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        /*scoreSystem.StartTimer();
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        asteroidSpawner.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);*/
    }
}
