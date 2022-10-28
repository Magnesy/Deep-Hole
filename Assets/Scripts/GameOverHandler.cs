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


    
    
    public void EndGame()
    {
        //asteroidSpawner.enabled = false;

        //gameOverText.text = "Your Score : " + finalScore;

        gameOverDisplay.gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevelButton()
    {
        int level = PlayerPrefs.GetInt(LevelKey, 1);
        SceneManager.LoadScene(level);
        level += 1;
        PlayerPrefs.SetInt(LevelKey , level + 1);
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
