using UnityEngine;
using UnityEngine.UI;

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
    }

}
