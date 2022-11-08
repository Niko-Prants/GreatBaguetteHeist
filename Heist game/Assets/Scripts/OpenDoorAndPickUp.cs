using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAndPickUp : MonoBehaviour
{
    GameObject normalDoor;
    GameObject lockedDoor;
    public bool pickedUpKey = false;
    public float texttimer = 0f;

    public int baguetteAmount = 0;
    GameObject key;
    GameObject baguette1;
    GameObject baguette2;
    GameObject baguette3;
    public GameObject NeedKeyCanvas;
    public GameObject PickedUpKey;
    public GameObject FoundBaguette;
 

    private void Start()
    {
        normalDoor = GameObject.FindGameObjectWithTag("normaldoor");
        lockedDoor = GameObject.FindGameObjectWithTag("lockeddoor");
        key = GameObject.FindGameObjectWithTag("key");

        baguette1 = GameObject.FindGameObjectWithTag("baguette1");
        baguette2 = GameObject.FindGameObjectWithTag("baguette2");
        baguette3 = GameObject.FindGameObjectWithTag("baguette3");
    }
    private void Update()
    {
        if(texttimer > 0)
        {
            texttimer -= Time.deltaTime;
            if(texttimer <= 0f)
            {
                texttimer = 0f;
                NeedKeyCanvas.SetActive(false);
                PickedUpKey.SetActive(false);
                FoundBaguette.SetActive(false);             }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //picks up key and enables popup with timer
        if (collision.gameObject.CompareTag("key"))
        {
            Soundsmanager.PlaySound("keysound");
            pickedUpKey = true;
            key.SetActive(false);
            PickedUpKey.SetActive(true);
            texttimer = 5;

        }

        //opens door
        if (collision.CompareTag("normaldoor"))
        {
            Soundsmanager.PlaySound("doorsound");
            normalDoor.SetActive(false);
        }
        if (collision.CompareTag("lockeddoor"))
        {
            //tells you to get a key
            NeedKeyCanvas.SetActive(true);
            texttimer = 5;
            //opens door if has key
            if (pickedUpKey == true)
            {
                Soundsmanager.PlaySound("doorsound");
                lockedDoor.SetActive(false);
            }
        }

        //picks up baguettes and enables popup with timer 
        if (collision.gameObject.CompareTag("baguette1"))
        {
            Soundsmanager.PlaySound("baguettesound");
            baguetteAmount += 1;
            baguette1.SetActive(false);
            FoundBaguette.SetActive(true);
            texttimer = 5f;
        }
        else if (collision.gameObject.CompareTag("baguette2"))
        {
            Soundsmanager.PlaySound("baguettesound");
            baguetteAmount += 1;
            baguette2.SetActive(false);
            FoundBaguette.SetActive(true);
            texttimer = 5f;
        }
        else if (collision.gameObject.CompareTag("baguette3"))
        {
            Soundsmanager.PlaySound("baguettesound");
            baguetteAmount += 1;
            baguette3.SetActive(false);
            FoundBaguette.SetActive(true);
            texttimer = 5f;
        }


        
    }

}
