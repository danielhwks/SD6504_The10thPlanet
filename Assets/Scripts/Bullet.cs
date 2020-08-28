using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public HeroScript hero;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
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