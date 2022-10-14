using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAndPickUp : MonoBehaviour
{
    GameObject normalDoor;
    GameObject lockedDoor;
    public bool pickedUpKey = false;

    public int baguetteAmount = 0;
    GameObject key;
    GameObject baguette1;
    GameObject baguette2;
    GameObject baguette3;

    private void Start()
    {
        normalDoor = GameObject.FindGameObjectWithTag("normaldoor");
        lockedDoor = GameObject.FindGameObjectWithTag("lockeddoor");
        key = GameObject.FindGameObjectWithTag("key");

        baguette1 = GameObject.FindGameObjectWithTag("baguette1");
        baguette2 = GameObject.FindGameObjectWithTag("baguette2");
        baguette3 = GameObject.FindGameObjectWithTag("baguette3");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //picks up key
        if (collision.gameObject.CompareTag("key"))
        {
            pickedUpKey = true;
            key.SetActive(false);

        }

        //opens door
        if (collision.CompareTag("normaldoor"))
        {
            normalDoor.SetActive(false);
        }
        if (collision.CompareTag("lockeddoor"))
        {
            //tells you to get a key
            Debug.Log("get key");
            //opens door if has key
            if (pickedUpKey == true)
            {
                lockedDoor.SetActive(false);
            }
        }
       
        //picks up baguettes
        if (collision.gameObject.CompareTag("baguette1"))
        {
            baguetteAmount += 1;
            baguette1.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("baguette2"))
        {
            baguetteAmount += 1;
            baguette2.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("baguette3"))
        {
            baguetteAmount += 1;
            baguette3.SetActive(false);
        }


        
    }

}
