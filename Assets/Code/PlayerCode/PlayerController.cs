using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    //Variables 
    private Rigidbody2D rb;
    public float moveSpeed;
    private float moveInput;

    Vector2 mousePosition;

    public Camera Playercam;
    public Shooting firepoint;
    public Shooting shooter;

    //see void flip \/
    private bool facingRight = true;

    //transform is for x,y coordinate of check to see if overlap is on terrain (public because a different script needs to see the x,y coordinates
    private bool OnTerrain;
    public Transform TerrainCheck;
    public float checkRadius;
    public LayerMask whatisTerrain; // lets you select in inspector what layer counts as ground

    //Jumping
    public float jumpForce;
    private float jumpTimerMax;
    public float jumpTime;
    private bool isJumping;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();





    }


    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        OnTerrain = Physics2D.OverlapCircle(TerrainCheck.position, checkRadius, whatisTerrain);

    }

    public void LateUpdate()
    {
        ProcessInputs();
    }

    // Update is called once per frame
    void Update()

    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (OnTerrain == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimerMax = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimerMax > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpForce);
                jumpTimerMax -= Time.deltaTime;
            }
            else
            {
                isJumping = false;

            }
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


    }
    void ProcessInputs()
    {
        if (Input.GetMouseButtonDown(1))
        {
            shooter.FireReg();
            //knockBack.Knockback();
        }
    }


void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
}
