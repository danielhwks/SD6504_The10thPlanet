using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //The positioning on the UI Script must be in FixedUpdate to avoid jittering effect when the camera moves.
    void FixedUpdate()
    {
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = Camera.main.aspect * cameraHalfHeight;
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 topLeftPos = new Vector3(-cameraHalfWidth, cameraHalfHeight, 0) + Camera.main.transform.position;
        topLeftPos += new Vector3(bounds.size.x / 2, -bounds.size.y / 2, 1);
        transform.position = topLeftPos;

    }
}
