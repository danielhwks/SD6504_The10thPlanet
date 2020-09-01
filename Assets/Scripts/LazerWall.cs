using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerWall : MonoBehaviour
{
    public float interval;
    public GameObject lazerWall1;
    public GameObject lazerWall2;
    public GameObject lazerWall3;
    public GameObject lazerWall4;
    public GameObject lazerWall5;
    public GameObject lazerWall6;

    void Start()
    {

    }

    public void ShowWall()
    {
        lazerWall1.SetActive(true);
        lazerWall2.SetActive(true);
        lazerWall3.SetActive(true);
        lazerWall4.SetActive(true);
        lazerWall5.SetActive(true);
        lazerWall6.SetActive(true);
        this.gameObject.SetActive(true);
    }

    IEnumerator HideCoroutine()
    {
        lazerWall1.SetActive(false);
        yield return new WaitForSeconds(interval);
        lazerWall2.SetActive(false);
        yield return new WaitForSeconds(interval);
        lazerWall3.SetActive(false);
        yield return new WaitForSeconds(interval);
        lazerWall4.SetActive(false);
        yield return new WaitForSeconds(interval);
        lazerWall5.SetActive(false);
        yield return new WaitForSeconds(interval);
        lazerWall6.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void HideWall()
    {
        StartCoroutine(HideCoroutine());
    }
}