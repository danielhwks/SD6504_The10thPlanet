using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hero;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public AudioSource gunShotSound;

    private GameObject bullet;

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
        gunShotSound.Play();
        bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = (bulletSpawn.transform.position - transform.position) * bulletSpeed;
    }
}