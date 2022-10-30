using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    //[SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject gameOverDisplay;
    private int maxLevel = 10;

    public const string LevelKey = "Level";
    public const string LastLevelKey = "LastLevel";

    public void RestartWin()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        if(level < maxLevel)
        {
            PlayerPrefs.SetInt(LevelKey , level);
            int lastLevel = PlayerPrefs.GetInt(LastLevelKey, 1);
            PlayerPrefs.SetInt(LastLevelKey , level + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public void RestartLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void NextLevelButton()
    {
        int level = PlayerPrefs.GetInt(LevelKey, 1);
        if(level < maxLevel)
        {
            SceneManager.LoadScene(level);
        }
        else 
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
