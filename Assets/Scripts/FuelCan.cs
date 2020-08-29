using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    public GameObject fuelCan;
    public HeroScript hero;
    public AudioSource collectionSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            collectionSound.Play();
            fuelCan.SetActive(false);
            hero.ImproveHealth(10f);
            hero.SetFuelCanScore();
        }
    }
}
