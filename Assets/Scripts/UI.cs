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

  public float getHealth() // Tar v�rdet av hur mycket healthbar �r fylld - Meher
    {
        return healthBar.fillAmount;
    }   
 
    public void UpdateHealth(float value) // S�tter m�ngden healthbar �r fylld till en variabel - Meher
    {
        healthBar.fillAmount = value;
        
    }
 
}
