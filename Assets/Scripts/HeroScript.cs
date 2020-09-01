﻿ using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HeroScript : MonoBehaviour
{
    public float jumpForce = 7.0f;
    public int movementSpeed = 7;
    private Animator anim;
    private bool onGround = false;
    private Rigidbody2D rb;
    private float scale;
    public static float heroHealth;
    public int heroCollectionScore;
    public int heroLife;
    public AudioSource jumpSound, deathSound, gameOver;
    GameObject pausedPanel, gameOverPanel;
    private bool paused;
    public Button QuitBtn;
    public Joystick joystick;
    float joystickHorizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        heroHealth = 100f;
        heroLife = 2;
        heroCollectionScore = 0;
        pausedPanel = GameObject.Find("PausedPanel");
        gameOverPanel = GameObject.Find("EndGamePanel");
        pausedPanel.transform.localScale = new Vector3(0, 0, 0);
        paused = false;
        Time.timeScale = 1;

        QuitBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("HomeScene");
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || (joystick.Vertical >= 0.5f))
        {
            anim.Play("HeroJumping");
            if (onGround == true)
            {
                jumpSound.Play();
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                onGround = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
        {
            paused = !paused;
            if (paused)
            {
                pausedPanel.transform.localScale = new Vector3(1, 1, 1);
                Time.timeScale = 0;
            }
            else
            {
                pausedPanel.transform.localScale = new Vector3(0, 0, 0);
                Time.timeScale = 1;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        joystickHorizontalMove = joystick.Horizontal;

        if (Input.GetKey("left") || (joystickHorizontalMove <= -0.2f))
        {
            anim.SetInteger("Trans", 2);
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            Vector2 scale = GetComponent<Transform>().localScale;
            scale.x = -1f;
            GetComponent<Transform>().localScale = scale;
        }
        if (Input.GetKey("right") || (joystickHorizontalMove >= 0.2f))
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
        joystickHorizontalMove = 0f;

        // Update UI
        Text distanceScore = GameObject.Find("UIDistanceScore").GetComponent<Text>();
        distanceScore.text = GetScore().ToString();
        Text collectionScore = GameObject.Find("UICanScore").GetComponent<Text>();
        collectionScore.text = heroCollectionScore.ToString();
        GameObject.Find("UIHeroLivesText").GetComponent<Text>().text = heroLife.ToString();
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        onGround = true;
        rb.velocity = new Vector2(movementSpeed, 0);
    }

    public void ImproveHealth(float healthAdd)
    {
        heroHealth += healthAdd;
        if(heroHealth > 100f)
        {
            heroHealth = 100f;
        }
    }

    public float GetHealth()
    {
        return heroHealth;
    }

    public void ReduceHealth(float healthRemove)
    {
        heroHealth -= healthRemove;
        StartCoroutine(Blink());
        if(heroHealth <= 0f)
        {
            anim.Play("HeroFall");
            ReduceLife();
        }
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


    private void ReduceLife()
    {
        deathSound.Play();
        heroLife = heroLife - 1;
        if (heroLife < 0)
        {
            gameOver.Play();
            GameOver();
            
        }
        else
        { 
            StartCoroutine(Revive());
            heroHealth = 100f;
        }
    }

    private IEnumerator Blink()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }

    private IEnumerator Revive()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(2f);
        anim.SetInteger("Trans", 5);        
        yield return new WaitForSeconds(1f);
        GetComponent<Renderer>().material.color = Color.white;
        anim.SetInteger("Trans", 0);
    }

    private void GameOver()
    {

        Text endDistanceScore = GameObject.Find("DistanceCoveredScore").GetComponent<Text>();
        Text endCanCollectedScore = GameObject.Find("CanCollectedScore").GetComponent<Text>();
        endDistanceScore.text = GetScore().ToString();
        endCanCollectedScore.text = heroCollectionScore.ToString();
        gameOverPanel.transform.localScale = new Vector3(1, 1, 1);
        Time.timeScale = 0;
    }

}
