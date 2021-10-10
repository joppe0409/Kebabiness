using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    Canvas pauseMenu;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GetComponent<Canvas>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                pauseMenu.enabled = true;
                isPaused = true;
                Time.timeScale = 0;
                AudioListener.pause = true;
            }

            if (isPaused == true)
            {
                pauseMenu.enabled = false;
                isPaused = false;
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
        }
    }
}
