using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{

    public Transform[] waypoints;
    public int targetPoint;
    public float speed;
    void Start()
    {
        targetPoint = 0;
    }

    void Update()
    {
        if(transform.position == waypoints[targetPoint].position)
        {
            //when on waypoint goes to "IncreaseTargetInt"
            increaseTargetInt();
        }
        //makes guard go to waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetPoint].position, speed * Time.deltaTime);
    }
    void increaseTargetInt()
    {
        //increases target number so the guard changes target and goes to next waypoint
        targetPoint++;

        //if target is greater than amount of waypoints ets target to 0
        if(targetPoint >= waypoints.Length)
        {
            targetPoint = 0;
        }
    }
}
