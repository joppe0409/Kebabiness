using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private bool isPaused;

    // Dessa variabler s�tts in i inspektorn om inte redan i prefab - Meher
    public Image healthBar;
    public Text pointText;

    public Enemies enemies; 

    public GameObject HP;
    public GameObject deathScreen;
    public GameObject pauseMenu;
    
    void Start()
    {
        // S�tter p� och st�nger av allt som beh�vs vid b�rjan av spelet - Meher

        deathScreen.SetActive(false);
        HP.SetActive(true);
        pauseMenu.SetActive(false);

        isPaused = false;
    }

    void Update()
    {
        // Skriver ut den po�ng man f�r, detta anv�nds i DeathScreen - Meher
        pointText.text = "Points: " + Enemies.points.ToString();

        // Ser till s� att spelet g�r att pausas och �terupptas genom att trycka p� Escape knappen. Anv�nder en boule f�r att best�mma vad som sker - Meher
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
    public void SetHealthBarColor(Color healthColor) // �ndrar p� v�rdet av healthbar - Meher
    {
        healthBar.color = healthColor;
    }

    public float getHealth() // Tar v�rdet av hur mycket healthbar �r fylld - Meher
    {
        return healthBar.fillAmount;
    }   
 
    public void UpdateHealth(float value) // S�tter m�ngden healthbar �r fylld till en variabel - Meher
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

    // Funktion som kallas i "Player" skriptet n�r spelaren "d�r" - Meher
    public void PlayerDeath()
    {
        deathScreen.SetActive(true);
        HP.SetActive(false);
        Time.timeScale = 0;
      
        AudioListener.pause = true;
    }

    // Funktioner f�r att s�tta p� och st�nga av pausmenyn, anv�nds �ven f�r knappar - Meher
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

    // Funktioner som anv�nds f�r buttons - Meher
    public void MainMenu() // G�r till start menyn - Meher
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu");
        
    }
}
