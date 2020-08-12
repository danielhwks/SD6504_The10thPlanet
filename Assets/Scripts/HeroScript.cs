using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;


public class HeroScript : MonoBehaviour
{
    public float jumpForce = 7.0f;
    public int movementSpeed = 7;
    private Animator anim;
    private bool onGround = false;
    private Rigidbody2D rb;
    private float scale;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            if (onGround == true)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                onGround = false;
                anim.SetTrigger("Jump");
            }
        }        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            Vector2 scale = GetComponent<Transform>().localScale;
            scale.x = -1f;
            GetComponent<Transform>().localScale = scale;
        }
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            
            Vector2 position = GetComponent<Transform>().position;
            position.x = position.x - 0.1f;
            Vector2 scale = GetComponent<Transform>().localScale;
            scale.x = 1f;
            GetComponent<Transform>().localScale = scale;
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        onGround = true;
        rb.velocity = new Vector2(movementSpeed, 0);
        print("Hero grounded");
    }

}
