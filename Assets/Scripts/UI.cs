using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealthBarColor(Color healthColor)
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
 
}
