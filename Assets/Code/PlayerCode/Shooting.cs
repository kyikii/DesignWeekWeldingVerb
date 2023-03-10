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
    public PlayerController playerController;
    [SerializeField] private AudioSource slimeShootSound; // More audio shizz
    [SerializeField] private AudioClip slimeShootClip; // Audio clip
    public void FireReg()
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Debug.Log("Weldy");
        

        slimeShootSound.PlayOneShot(slimeShootClip);
        Debug.Log("slimeShootSound Plays"); 
    }
}
