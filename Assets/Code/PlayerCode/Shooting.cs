using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject BigBullet;

    public Transform firePoint;
    public float bulletForce;

    public Rigidbody2D rb;
    public float recoilForce = 10000f;
    public PlayerController playerController;


    public void Fire()
    {


        GameObject projectile = Instantiate(BigBullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


        //GameObject player = IDKWhatICanPutHere!!!!(rb,firePoint.position, firePoint.rotation);
        //player.GetComponent<Rigidbody2D>().AddForce(-firePoint.up * recoilForce, ForceMode2D.Impulse);

        //rb.AddForce(-firePoint.up * recoilForce, ForceMode2D.Impulse);


        //The Final solution???
        rb.AddForce(-firePoint.up * recoilForce);
        Debug.Log("GoFlying!");
    }

    public void FireReg()
    {


        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        Debug.Log("Weldy");
    }

    /*
        public void Knockback()
        {

            playerController.AddForce(-firePoint.up * recoilForce);
            Debug.Log("GoFlying!");
        }
    */

}
