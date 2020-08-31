using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private const int maxHeroHealth = 100;
    public Slider healthBar;
    public HeroScript hero;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHeroHealth;
        healthBar.value = maxHeroHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = hero.GetHealth();
    }
}
