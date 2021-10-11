using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    public static ScreenShakeController instance;

    private float shakeTimeRemaining, shakePower, shakeFaidTime, shakeRotation;

    public float rotationMultiplier;
   

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

     
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime; // tar bort från tiden skakningen händer, Johan.

            float xAmount = Random.Range(-.5f, .5f) * shakePower; // xAmount blir en siffra mellan -5 och 5 multipliserat med shakePower, Johan.
            float yAmount = Random.Range(-.5f, .5f) * shakePower; // samma som det ovan fast yAmount, Johan.

            transform.position += new Vector3(xAmount, yAmount, 0f); // positionen på kameran ändras enligt hur mycket x och y amount är, Johan.

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFaidTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFaidTime * rotationMultiplier * Time.deltaTime);
        }
        if(shakeTimeRemaining <= 0)
        {
            transform.position = Vector3.zero; // Om Skaknings tiden är mindre eller lika med noll så blir kamerans position 0 på alla positions värden, Johan.
        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f)); // Rotationen på kameran ändras enligt shakeRotation miltiplicerat med en slumpmässig siffra mellan -1 och 1 på z axis, Johan.
    }

    public void startShake(float length, float power) // funktinen har svå floats som man ändrar när funktionen blir kallat, Johan.
    {
        shakeTimeRemaining = length; // shakeTimeRemaining blir samma som length vilket väls när funktionen kallas alltså väljer man tiden kameran skakar, Johan.
        shakePower = power; 

        shakeFaidTime = power / length; // Denna kod gör så att skakningen inte slutar direkt utan tonas bort, Johan.

        shakeRotation = power * rotationMultiplier;
    }
}
