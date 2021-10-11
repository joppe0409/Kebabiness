using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    Canvas pauseMenu;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GetComponent<Canvas>();
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        } // Ser till så att spelet går att pausas och återupptas genom att trycka på Escape knappen. Använder en boule för att bestämma vad som sker - Meher
    }

    public void Pause() 
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        isPaused = true;
        AudioListener.pause = true;
    }
    // Sätter på/stänger av paus kanvasen och stoppar/återupptar spelet - Meher
    public void Resume()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        isPaused = false;
        AudioListener.pause = false;
    }

    // Funktioner som används för buttons - Meher
   
    public void MainMenu() // Går till start menyn - Meher
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
