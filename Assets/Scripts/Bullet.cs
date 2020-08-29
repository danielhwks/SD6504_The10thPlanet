using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private HeroScript hero;
    public float damage;
    public AudioSource heroDamagedSound;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<HeroScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered");
        string name = collider.gameObject.name;
        if (name == "Hero")
        {
            // Deal damage
            Debug.Log("Has Hero true");
            heroDamagedSound.Play();
            hero.ReduceHealth(damage);
        }
        else if (name == "FuelCan" || name == "Trigger")
        {
            // Do nothing
            return;
        }
        else
        {
            // Floor, Grate, Guns
            // Destroy self
            Destroy(this.gameObject);
        }
    }
}