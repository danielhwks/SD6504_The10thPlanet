using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HeroFollower : MonoBehaviour
{
    public GameObject heroCopy;
    // Start is called before the first frame update
    void Start()
    {
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        float edge = 12.36f;
        float offset = screenHalfWidth - edge;
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.localPosition = new Vector3(offset, camera.transform.localPosition.y, camera.transform.localPosition.z);
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
