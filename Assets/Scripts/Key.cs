using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject lazerWall;
    public AudioSource keyCollectedSound;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Hero")
        {
            keyCollectedSound.Play();
            lazerWall.GetComponent<LazerWall>().HideWall();
            this.gameObject.SetActive(false);
        }
    }
}