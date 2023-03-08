using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private bool mouseClicked = false;
    private Vector3 offset;
    private Rigidbody2D rb2D;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    void OnMouseDown()
    {
        if (tag == "Metallic")
        {
            mouseClicked = true;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }
    
    void OnMouseUp()
    {
        mouseClicked = false;
    }
    
    void Update()
    {
        if (mouseClicked)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) + offset;
            rb2D.MovePosition(newPosition);
        }
    }
}