using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
  public void UpdatehealthText(int currentHealth, int maxHealth)
    {
        healthText.text = currentHealth + "/" + maxHealth.ToString();
        float newCurrentHealth = (float)currentHealth / maxHealth;
            healthSlider.value = newCurrentHealth;
    }
}
