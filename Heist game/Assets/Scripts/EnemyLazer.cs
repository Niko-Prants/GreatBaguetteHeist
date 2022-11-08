using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public GameObject beam;
    public GameObject beam2;
    GameObject player;
    public float timeRemaining = 3;
    private double sec;
    void Start()
    {
        beam = GameObject.FindGameObjectWithTag("beam");
        beam2 = GameObject.FindGameObjectWithTag("beam2");


    }

    private void Update()
    {
        
        //counts down from 5
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        //sets counter back to 3 when hits 0
        else if (timeRemaining < 0)
        {
            timeRemaining = 3;
            //counts sec up everytime counter has hit 0
            sec += 1;
        }

        //sets beam inactive when "sec" is even
        if(sec % 2 == 0)
        {
            beam.SetActive(false);
            beam2.SetActive(false);
        }
        //sets beam active when "sec" is odd
        if (sec % 2 == 1)
        {
            beam.SetActive(true);
            beam2.SetActive(true);
        }
    }

  
}
