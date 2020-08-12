using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class heroFollower : MonoBehaviour
{
    public GameObject heroCopy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(heroCopy.transform.position.x > transform.position.x)
        {
            transform.position = new Vector2(heroCopy.transform.position.x, -2.05f);
        }
    }
}
