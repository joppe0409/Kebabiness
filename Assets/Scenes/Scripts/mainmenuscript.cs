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
        FindObjectOfType<AudioManager>().Play("MenyLåt");
    }
    public void quitGame() 
    {
        Application.Quit(); // Med hjälp av denna funktion kan vi stänga ner den nuvarande "running applicationen" i spelet. - Freja Holmgren Jakobsson.

    }
}
