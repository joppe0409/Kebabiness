using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public float getHealth() // Tar värdet av hur mycket healthbar är fylld - Meher
    {
        return healthBar.fillAmount;
    }   
 
    public void UpdateHealth(float value) // Sätter mängden healthbar är fylld till en variabel - Meher
    {
        healthBar.fillAmount = value;
        
    }
 
}
