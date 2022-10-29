using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private GameObject navigator;
    [SerializeField] private GameObject explosion;
    private float value;
    
    
    private void Start() 
    {
        value = 100f / GameObject.FindGameObjectsWithTag("Objects").Length;
    }
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Objects"))
        {
            other.gameObject.SetActive(false);

            slider.value += value;

            if(slider.value >= 99.5f)
            {
                Invoke("GameOverDisplay",1);
            }
        }
        if(other.CompareTag("bomb"))
        {
            other.gameObject.SetActive(false);
            explosion.SetActive(true);
            Invoke("GameOverDisplay",1);
            navigator.GetComponent<HoleHandler>().enabled = false;

        }
    }
    
    public void GameOverDisplay()
    {
        gameOverDisplay.gameObject.SetActive(true);
    }

}
