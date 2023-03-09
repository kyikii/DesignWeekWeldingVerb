using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject bullet;

    public void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            Destroy(gameObject);




        /*
        if (GameObject.bullet collides ))

        {

        }

        */



    }

    public GameObject jointFab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is between two objects that can be joined (First checks for colliding object and second is the object in wich the script is attatched too)
        if (collision.gameObject.CompareTag("Metallic") && gameObject.CompareTag("Metallic"))
        {
            // Create a new 'FixedJoint2D' component and attaches it to each of the colliding objects
            FixedJoint2D joint = collision.gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = gameObject.GetComponent<Rigidbody2D>();

            // If a joint prefab is specified we shall instantiate it and parent it to the current object
            if (jointFab != null)
            {
                GameObject jointObj = Instantiate(jointFab, transform);
                jointObj.transform.position = collision.GetContact(0).point;
                jointObj.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }

}
