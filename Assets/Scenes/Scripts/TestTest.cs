using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTest : MonoBehaviour
{
    public UI ui;

    public float health = 5;
    // Start is called before the first frame update
    void Start()
    {
        ui.UpdateHealth(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        ui.UpdateHealth(ui.getHealth() - 0.2f);
    }
}
