using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject exitbutton;
    [SerializeField] private GameObject startSlider;


    public const string LevelKey = "Level";
    public const string LastLevelKey = "LastLevel";
    public void Start()
    {
        int level = PlayerPrefs.GetInt(LevelKey, 1);
        int Lastlevel = PlayerPrefs.GetInt(LastLevelKey, 1);
        //levelText.text = "Level : " + Lastlevel;
        
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        exitbutton.SetActive(false);
        startSlider.SetActive(true);

        Invoke("LoadLastLevel", 3.2f);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void LoadLastLevel()
    {
        int Lastlevel = PlayerPrefs.GetInt(LastLevelKey, 1);
        SceneManager.LoadScene(Lastlevel);
    }
    
}
