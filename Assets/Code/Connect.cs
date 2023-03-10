using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Connect : MonoBehaviour
{
    public GameObject jointFab;
    [SerializeField] private AudioSource weldingSFX; // Audiosource used for sounds (duh)
        private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is between two objects that can be joined (First checks for colliding object and second is the object in wich the script is attatched too)
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("ITS A HITTER");
            // Create a new 'FixedJoint2D' component and attaches it to each of the colliding objects
            FixedJoint2D joint = collision.gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = gameObject.GetComponent<Rigidbody2D>();

                        
            weldingSFX.Play(); // Hopefully plays the sound :pray:
            Debug.Log("weldingSFX Plays");

            // If a joint prefab is specified we shall instantiate it and parent it to the current object
            if (jointFab != null && !weldingSFX.isPlaying)
            {
                GameObject jointObj = Instantiate(jointFab, transform);
                jointObj.transform.position = collision.GetContact(0).point;
                jointObj.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();

            }
        }
    }
}