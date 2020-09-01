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
    public GameObject specialPrefab;
    public GameObject specialKey;
    public GameObject specialWall;
    private int specialCounter;

    // Start is called before the first frame update
    void Start()
    {
        if (specialPrefab) {
            specialCounter = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name != "Hero")
            return;

        GameObject selectedPrefab = prefabMove;
        
        if (specialPrefab) {
            if (specialCounter == 0)
            {
                specialCounter = 2;
                selectedPrefab = specialPrefab;
                specialKey.SetActive(true);
                specialWall.GetComponent<LazerWall>().ShowWall();
            }
            else
            {
                specialCounter -= 1;
            }
        }

        Vector3 temp = currentPrefab.transform.position;
        temp.x = temp.x + incrementX;
        selectedPrefab.transform.position = temp;

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
