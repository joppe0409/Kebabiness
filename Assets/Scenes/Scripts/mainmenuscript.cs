using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuscript : MonoBehaviour
{
    AudioManager aM;
    private void Start()
    {
        aM = FindObjectOfType<AudioManager>(); // hittar AudioManager objektet, Johan.
        Time.timeScale = 1;
        AudioListener.pause = false;
        FindObjectOfType<AudioManager>().Play("MenyL�t");
    }
    public void quitGame() 
    {
        Application.Quit(); // Med hj�lp av denna funktion kan vi st�nga ner den nuvarande "running applicationen" i spelet. - Freja Holmgren Jakobsson.

    }
}
