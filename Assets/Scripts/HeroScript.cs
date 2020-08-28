using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class HeroScript : MonoBehaviour
{
    public float jumpForce = 7.0f;
    public int movementSpeed = 7;
    private Animator anim;
    private bool onGround = false;
    private Rigidbody2D rb;
    private float scale;
    public static float heroHealth;
    public static int heroCollectionScore;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        heroHealth = 100f;
        heroCollectionScore = 0;
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

        // Update UI
        Text score = GameObject.Find("UIHeroScore").GetComponent<Text>();
        score.text = GetScore().ToString();
        Text heroHealthUI = GameObject.Find("UIHeroHealth").GetComponent<Text>();
        heroHealthUI.text = heroHealth.ToString();
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

    public int GetScore()
    {
        GameObject follower = GameObject.Find("HeroFollower");
        return (int)follower.transform.position.x - 9;
    }

    public int SetFuelCanScore()
    {
        return heroCollectionScore++;
    }
}
