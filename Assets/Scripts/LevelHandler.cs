using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text levelText;
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
        int Lastlevel = PlayerPrefs.GetInt(LastLevelKey, 1);
        SceneManager.LoadScene(Lastlevel);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    
}
