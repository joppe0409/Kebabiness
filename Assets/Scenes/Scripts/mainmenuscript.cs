using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuscript : MonoBehaviour
{
  
    private void Start()
    {
      
        Time.timeScale = 1;

    }
  
    public void quitGame() 
    {
        Application.Quit(); // Med hjälp av denna funktion kan vi stänga ner den nuvarande "running applicationen" i spelet. - Freja Holmgren Jakobsson.

    }
}
