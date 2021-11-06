using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skott : MonoBehaviour
{
    public Transform firePoint, firePoint2;
    public GameObject bulletPrefab, bullet, bullet2;
    public Rigidbody2D rb, rb2;
    private Animator anim;
    public float bulletForce = 30f;

    public float maxBullets = 7f;
    public float ammo = 7f;
    public float reloadTime = 10f;
    public bool haveAmmo = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (haveAmmo == true && Input.GetButtonDown("Fire1") ) // om man har ammo och trycker på vänster musknapp så händer det i if satsen, Johan.
        {
            Shoot();
            ammo -= 1f;
            
        }

        if (ammo == -1) // om ammo är lika med -1 så är haveAmmo lika med falskt och så startas en courontine, Johan.
        {
            haveAmmo = false;
            StartCoroutine(Reloading());
        }

      
    }
   
   

    void Shoot()
    {
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Den här koden instatiatar Bullet prefaben vid firepoints position och rotation och säger även att gameobjectet bullet är samma som allt efter lika med tecknet, Johan.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Här hämtar koden bullets ridgidbody 2d, Johan.
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // Här tas ridgodbodyn och lägger till en kraft i firepoints up position vilket alltid kommer vara håller firepoint pekar, sen multipliceras det med bulletforce och till sist skrivs det att kraften ska vara i impulse mode, Johan.

        bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
    }


    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime); //väntar i så många seunder reloadTime är satt på, Johan.
        anim.SetBool("isCool", true); // Här säger jag åt våran animatior att transitionen med boolen isCool ska starta samt att kommande animation skall spelas. - Freja Holmgren Jakobsson
        ammo = 7f;
        haveAmmo = true;
    }





}
