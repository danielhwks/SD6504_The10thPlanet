using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class HeroScript : MonoBehaviour
{
    public float jumpForce = 7.0f;
    public GameObject gameObj;
    public int movementSpeed = 7;
    private Animator anim;
    private bool onGround = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObj.GetComponent<Rigidbody2D>();
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

    void OnCollisionEnter2D(Collision2D hit)
    {
        onGround = true;
        print("Hero has collided with ground");
    }

}
