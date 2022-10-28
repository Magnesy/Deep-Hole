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
        }
        if(other.CompareTag("bomb"))
        {
            other.gameObject.SetActive(false);
            gameOverDisplay.gameObject.SetActive(true);
            navigator.gameObject.SetActive(false);

        }
    }

}
