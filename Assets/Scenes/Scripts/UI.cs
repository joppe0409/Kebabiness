using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private bool isPaused;

    // Dessa variabler sätts in i inspektorn om inte redan i prefab - Meher
    public Image healthBar;
    public Text pointText;

    public Enemies enemies; 

    public GameObject HP;
    public GameObject deathScreen;
    public GameObject pauseMenu;
    
    void Start()
    {
        // Sätter på och stänger av allt som behövs vid början av spelet - Meher

        deathScreen.SetActive(false);
        HP.SetActive(true);
        pauseMenu.SetActive(false);

        isPaused = false;
    }

    void Update()
    {
        // Skriver ut den poäng man får, detta används i DeathScreen - Meher
        pointText.text = "Points: " + Enemies.points.ToString();

        // Ser till så att spelet går att pausas och återupptas genom att trycka på Escape knappen. Använder en boule för att bestämma vad som sker - Meher
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Pause();
            }

            else if (isPaused == true)
            {
                Resume();
            }
        } 
    }

    // HealthBar funktioner - Meher
    public void SetHealthBarColor(Color healthColor) // Ändrar på värdet av healthbar - Meher
    {
        healthBar.color = healthColor;
    }

    public float getHealth() // Tar värdet av hur mycket healthbar är fylld - Meher
    {
        return healthBar.fillAmount;
    }   
 
    public void UpdateHealth(float value) // Sätter mängden healthbar är fylld till en variabel - Meher
    {
        healthBar.fillAmount = value;
        if (healthBar.fillAmount < 0.3f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (healthBar.fillAmount < 0.7f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    // Funktion som kallas i "Player" skriptet när spelaren "dör" - Meher
    public void PlayerDeath()
    {
        deathScreen.SetActive(true);
        HP.SetActive(false);
        Time.timeScale = 0;
      
        AudioListener.pause = true;
    }

    // Funktioner för att sätta på och stänga av pausmenyn, används även för knappar - Meher
    public void Pause()
    {
        pauseMenu.SetActive(true);  
        Time.timeScale = 0;
        isPaused = true;
        AudioListener.pause = true;
        HP.SetActive(false);
    }
   
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        AudioListener.pause = false;
        HP.SetActive(true);
    }

    // Funktioner som används för buttons - Meher
    public void MainMenu() // Går till start menyn - Meher
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu");
        
    }
}
