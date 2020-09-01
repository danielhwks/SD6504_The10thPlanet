using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject lazerWall;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       lazerWall.GetComponent<LazerWall>().HideWall();
       this.gameObject.SetActive(false); 
    }
}