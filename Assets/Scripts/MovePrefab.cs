using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public GameObject prefabMove;
    public GameObject currentPrefab;
    public float incrementX;
    public GameObject fuelCan;
    public GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        Vector3 temp = currentPrefab.transform.position;
        temp.x = temp.x + incrementX;
        //Vector3 temp = prefabMove.transform.position;
        //temp.x = temp.x + incrementX;
        prefabMove.transform.position = temp;

        Random random = new Random();
        int choice = Random.Range(0, 2);
        if (choice == 0)
        {
            fuelCan.SetActive(true); 
            laser.SetActive(false);
        }
        else if (choice == 1)
        {
            fuelCan.SetActive(false); 
            laser.SetActive(true);
        }


    }
    void OnTriggerStay2D()
    {

    }
    void OnTriggerExit2D()
    {

    }
}
