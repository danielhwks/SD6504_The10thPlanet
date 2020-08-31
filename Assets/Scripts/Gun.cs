using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hero;
    public GameObject heroFollower;
    public GameObject gun;
    public GameObject bulletSpawn;
    //public GameObject bulletPrefab;
    public GameObject bullet;
    public float bulletSpeed;
    public AudioSource gunShotSound;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gun.GetComponent<Animator>();
        InvokeRepeating("CheckFire", 4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = hero.transform.position - transform.position;
    }

    void CheckFire()
    {
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        float distance = Vector2.Distance(heroFollower.transform.position * new Vector2(1, 0), transform.position * new Vector2(1, 0));
        if (distance < screenHalfWidth)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        anim.Play("GunCharging");
        yield return new WaitForSeconds(0.5f);
        anim.Play("GunFiringAnimation");
        gunShotSound.Play();
        //bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        bullet.transform.position = bulletSpawn.transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody2D>().velocity = (bulletSpawn.transform.position - transform.position) * bulletSpeed;
    }
}