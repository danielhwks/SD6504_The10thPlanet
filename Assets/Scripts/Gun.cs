using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hero;
    public GameObject heroFollower;
    public GameObject bulletSpawn;
    //public GameObject bulletPrefab;
    public GameObject bullet;
    public float bulletSpeed;
    public AudioSource gunShotSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = hero.transform.position - transform.position;
    }

    void Fire()
    {
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        float distance = Vector2.Distance(heroFollower.transform.position * new Vector2(1, 0), transform.position * new Vector2(1, 0));
        if (distance < screenHalfWidth)
        {
            gunShotSound.Play();
            //bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
            bullet.transform.position = bulletSpawn.transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = (bulletSpawn.transform.position - transform.position) * bulletSpeed;
        }
    }
}