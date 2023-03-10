using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject crate;

    public Transform spawnPoint;
    public bool activated = false;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {


       
    }

    // Update is called once per frame
    public void Spawn()
    {


        if (activated == true)
        {
            GameObject newObject;
            newObject = Instantiate(crate, spawnPoint, spawnPoint);

        }
       
    }   
}
