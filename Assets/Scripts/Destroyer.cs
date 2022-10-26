using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Slider slider;
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

            SceneManager.LoadScene(1);
        }
    }

}
