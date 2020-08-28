using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public static float heroHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        heroHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            anim.Play("HeroJumping");
            if (onGround == true)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                onGround = false;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (Input.GetKey("left"))
        {
            anim.SetInteger("Trans", 2);
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            Vector2 scale = GetComponent<Transform>().localScale;
            scale.x = -1f;
            GetComponent<Transform>().localScale = scale;
        }
        if (Input.GetKey("right"))
        {
            anim.SetInteger("Trans", 2);
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            
            Vector2 position = GetComponent<Transform>().position;
            position.x = position.x - 0.1f;
            Vector2 scale = GetComponent<Transform>().localScale;
            scale.x = 1f;
            GetComponent<Transform>().localScale = scale;
        }
        if (!Input.anyKey)
        {
            anim.SetInteger("Trans", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        onGround = true;
        rb.velocity = new Vector2(movementSpeed, 0);
        print("Hero grounded");
    }

    public void ImproveHealth(float healthAdd)
    {
        heroHealth += healthAdd;
        if(heroHealth > 100f)
        {
            heroHealth = 100f;
        }
        print("Hero Health: " + heroHealth);
    }

    public void ReduceHealth(float healthRemove)
    {
        heroHealth -= healthRemove;
        if(heroHealth < 0f)
        {
            heroHealth = 0f;
            anim.Play("HeroFall");
        }
        print("Hero Health: " + heroHealth);
    }

    public void GetScore()
    {
        return (int)transform.position.x;
    }
}
