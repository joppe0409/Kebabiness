using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuscript : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void quitGame() 
    {
        Application.Quit(); // Med hj�lp av denna funktion kan vi st�nga ner den nuvarande "running applicationen" i spelet. - Freja Holmgren Jakobsson.

    }
}
