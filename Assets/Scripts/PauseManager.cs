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
        } // Ser till s� att spelet g�r att pausas och �terupptas genom att trycka p� Escape knappen. Anv�nder en boule f�r att best�mma vad som sker - Meher
    }

    public void Pause() 
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        isPaused = true;
        AudioListener.pause = true;
    }
    // S�tter p�/st�nger av paus kanvasen och stoppar/�terupptar spelet - Meher
    public void Resume()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        isPaused = false;
        AudioListener.pause = false;
    }

    // Funktioner som anv�nds f�r buttons - Meher
   
    public void MainMenu() // G�r till start menyn - Meher
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
